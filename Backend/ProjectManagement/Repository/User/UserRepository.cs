using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.User
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ProjectManagementContext context;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserRepository(ProjectManagementContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<IUserModel> GetUserAsync(string username)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Username == username);
            await context.UserRole.FirstOrDefaultAsync(u => u.UserId == user.Id);
            var test = await context.OrganizationRole.FirstOrDefaultAsync(u => u.UserId == user.Id);
            user.OrganizationRole = await context.OrganizationRole.FirstOrDefaultAsync(u => u.UserId == user.Id);
            return mapper.Map<IUserModel>(user);
        }

        public async Task<List<IUserModel>> GetAllAsync(IFiltering filterObj, ISorting sortObj, IPaging pagingObj)
        {
            //var allUsers = await unitOfWork.UserRepository.Get(pagingObj, filter: w => w.FirstName == filterObj.FilterValue, sortObj, orderBy: q => q.OrderBy(d => d.FirstName),
            //    orderByDescending: q => q.OrderByDescending(d => d.FirstName));
            var allUsers = await unitOfWork.UserRepository.Get(null, null, null);
            return mapper.Map<List<IUserModel>>(allUsers);
        }

    public async Task<IUserModel> GetByIdAsync(Guid id)
        {
            var user = await unitOfWork.UserRepository.GetByID(id);
            return mapper.Map<IUserModel>(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await unitOfWork.UserRepository.GetByID(id);
            if (user != null)
            {
               unitOfWork.UserRepository.Delete(user);
               await unitOfWork.SaveAsync(); 
               return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(IUserModel userParam, string password = null)
        {
            var user = await unitOfWork.UserRepository.GetByID(userParam.Id);

            if (user == null)
            {
                throw new AppException("User not found");
            }

            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                var allUsers = await unitOfWork.UserRepository.Get(null, null, null);
                if (allUsers.Any(x => x.Username == userParam.Username))
                {
                    throw new AppException("Username " + userParam.Username + " is already taken");
                }

                user.Username = userParam.Username;
            }

            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
            {
                user.FirstName = userParam.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
            {
                user.LastName = userParam.LastName;
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            unitOfWork.UserRepository.Update(user);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IUserModel> CreateAsync(IUserModel user, string password)
        {
            DAL.Entities.User newUser = mapper.Map<DAL.Entities.User>(user);

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }

            var allUsers = await unitOfWork.UserRepository.Get(null, null, null);
            if (allUsers.Any(x => x.Username == user.Username))
            {
                throw new AppException("Username \"" + user.Username + "\" is already taken");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            newUser.Id = Guid.NewGuid();
            newUser.DateCreated = DateTime.Now;
            newUser.DateUpdated = DateTime.Now;
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            var userRole = new UserRole {
                Id = Guid.NewGuid(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                Name = Role.User,
                Abrv = Role.User,
                UserId = newUser.Id,
             };

            await unitOfWork.UserRepository.Create(newUser);
            await unitOfWork.UserRole.Create(userRole);
            await unitOfWork.SaveAsync();

            return mapper.Map<IUserModel>(newUser);
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
