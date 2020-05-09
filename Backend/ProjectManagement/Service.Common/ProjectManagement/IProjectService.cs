using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface IProjectService
    {
        Task<IProjectModel> CreateAsync(Guid userId, IProjectModel project);
        Task<IEnumerable<IProjectModel>> GetAllAsync(Guid userId, IPaging paging, IFiltering filtering);
        Task<int> DeleteAsync(Guid id);
        Task<int> UpdateAsync(Guid id, IProjectModel project);
    }
}
