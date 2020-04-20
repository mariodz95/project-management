using AutoMapper;
using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper mapper;
        private readonly AppSettings appSettings;

        public UserService(IUserRepository userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        public async Task<IUserModel> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = await userRepository.GetUserAsync(username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public string GetToken(IUserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.Abrv)
                }),
                Expires = DateTime.UtcNow.AddHours(9),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public async Task<List<IUserModel>> GetAll(IFiltering filterObj, ISorting sortObj, IPaging pagingObj)
        {
            var users = await userRepository.GetAllAsync(filterObj, sortObj, pagingObj);
            return mapper.Map<List<IUserModel>>(users);
        }

        public async Task<IUserModel> GetByIdAsync(Guid id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        public async Task<IUserModel> CreateAsync(IUserModel model, string userPassword)
        {
            return await userRepository.CreateAsync(model, userPassword);
        }

        public async Task<bool> UpdateAsync(Guid id, IUserModel user, string password = null)
        {
            user.Id = id;
            return await userRepository.UpdateAsync(user, password);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await userRepository.DeleteAsync(id);
        }

        public virtual void Dispose(bool disposing)
        {
            userRepository.Dispose(disposing);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
