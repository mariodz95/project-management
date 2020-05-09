using Common.Interface_Sort_Pag_Flt;
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
        Task<IUserModel> Authenticate(string username, string password);
        Task<List<IUserModel>> GetAll(Guid organizationId);
        Task<IUserModel> GetByIdAsync(Guid id);
        Task<IUserModel> CreateAsync(IUserModel model, string userPassword);
        string GetToken(IUserModel user);
    }
}