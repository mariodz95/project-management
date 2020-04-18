using AutoMapper;
using Common.Helpers;
using DAL;
using DAL.Entities;
using Model;
using Model.Common;
using Repository.Common.User;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = await _userRepository.GetUser(username);

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

        public async Task<List<IUserModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<IUserModel>>(users);
        }

        public async Task<IUserModel> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<IUserModel>(user);
        }

        public async Task<User> Create(RegisterModel model)
        {
            var password = model.Password;
            var user = _mapper.Map<User>(model);
            return await _userRepository.Create(user, password);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateModel model, string password = null)
        {
            var user = _mapper.Map<User>(model);
            user.Id = id;
            return await _userRepository.UpdateAsync(user, password);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
             return await _userRepository.DeleteAsync(id);
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