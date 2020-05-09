using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

            return mapper.Map<IUserModel>(user);
        }

        public string GetToken(IUserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //TODO user roles
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    //new Claim(ClaimTypes.Role, user.UserRole.Abrv),
                    user.OrganizationRole != null ? new Claim(ClaimTypes.Role, user.OrganizationRole.Abrv) : null,
                }),
                Expires = DateTime.UtcNow.AddHours(9),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public async Task<List<IUserModel>> GetAll(Guid organizationId)
        {
            var users = await userRepository.GetAllByOrganizationIdAsync(organizationId);
            return mapper.Map<List<IUserModel>>(users);
        }

        public async Task<IUserModel> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return mapper.Map<IUserModel>(user);
        }

        public async Task<IUserModel> CreateAsync(IUserModel model, string userPassword)
        {
            DAL.Entities.User newUser = mapper.Map<DAL.Entities.User>(model);

            if (string.IsNullOrWhiteSpace(userPassword))
            {
                throw new AppException("Password is required");
            }


            if (await userRepository.CheckIfExistAsync(model.Username))
            {
                throw new AppException("Username \"" + model.Username + "\" is already taken");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userPassword, out passwordHash, out passwordSalt);

            newUser.Id = Guid.NewGuid();
            newUser.DateCreated = DateTime.Now;
            newUser.DateUpdated = DateTime.Now;
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            //TODO user roles
            //var userRole = new UserRole
            //{
            //    Id = Guid.NewGuid(),
            //    DateUpdated = DateTime.Now,
            //    DateCreated = DateTime.Now,
            //    Name = Role.User,
            //    Abrv = Role.User,
            //    UserId = newUser.Id,
            //};

            //newUser.UserRole = userRole;
            await userRepository.CreateAsync(newUser);
           
            return mapper.Map<IUserModel>(newUser);
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

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
