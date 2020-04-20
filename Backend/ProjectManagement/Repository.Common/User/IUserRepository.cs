using Common.Interface_Sort_Pag_Flt;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUserRepository : IDisposable
    {
        Task<IUserModel> GetUserAsync(string username);
        Task<List<IUserModel>> GetAllAsync(IFiltering filterObj, ISorting sortObj, IPaging pagingObj);
        Task<IUserModel> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<IUserModel> CreateAsync(IUserModel user, string password);
        Task<bool> UpdateAsync(IUserModel userParam, string password = null);
        void Dispose(bool disposing);
    }
}
