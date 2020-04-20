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
        Task<List<IUserModel>> GetAll(IFiltering filterObj, ISorting sortObj, IPaging pagingObj);
        Task<IUserModel> GetByIdAsync(Guid id);
        Task<IUserModel> CreateAsync(IUserModel model, string userPassword);
        Task<bool> UpdateAsync(Guid id, IUserModel user, string password = null);
        Task<bool> DeleteAsync(Guid id);
        string GetToken(IUserModel user);
        void Dispose(bool disposing);
    }
}