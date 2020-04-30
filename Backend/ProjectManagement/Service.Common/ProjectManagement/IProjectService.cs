using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface IProjectService
    {
        Task<IProjectModel> CreateAsync(Guid userId, IProjectModel organization);
        Task<IEnumerable<IProjectModel>> GetAllAsync(Guid userId, IPaging paging);
        Task<int> DeleteAsync(Guid id);
    }
}
