using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUserRepository 
    {
        Task<User> GetUserAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<bool> CheckIfExistAsync(string name);
        Task<int> CreateAsync(User user);
    }
}
