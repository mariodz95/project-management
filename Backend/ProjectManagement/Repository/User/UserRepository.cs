using AutoMapper;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private ProjectManagementContext context;

        public UserRepository(ProjectManagementContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            user.UserRole = await context.UserRole.FirstOrDefaultAsync(u => u.UserId == user.Id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return  await context.Users.ToListAsync();
        }

        public async Task<int> CreateAsync(User user)
        {
            await context.Users.AddAsync(user);
            var result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<DAL.Entities.User> GetByIdAsync(Guid id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<bool> CheckIfExistAsync(string name)
        {
            var exist = await context.Users.AnyAsync(u => u.Username == name);
            return exist;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
               context.Users.Remove(user);
                await context.SaveChangesAsync();
               return true;
            }
            return false;
        }
    }
}
