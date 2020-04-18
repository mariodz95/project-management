using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.User
{
    public interface IUserRepository
    {
        Task<DAL.Entities.User> GetUser(string username);
        Task<List<DAL.Entities.User>> GetAll();
        Task<DAL.Entities.User> GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<DAL.Entities.User> Create(DAL.Entities.User user, string password);
        Task<bool> UpdateAsync(DAL.Entities.User userParam, string password = null);
    }
}
