using DAL.Entities;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<List<IUserModel>> GetAll();
        Task<IUserModel> GetById(Guid id);
        Task<User> Create(RegisterModel model);
        Task<bool> UpdateAsync(Guid id, UpdateModel model, string password = null);
        Task<bool> DeleteAsync(Guid id);
    }
}