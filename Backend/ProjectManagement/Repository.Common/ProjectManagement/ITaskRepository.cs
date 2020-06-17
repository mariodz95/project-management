using Common.Interface_Sort_Pag_Flt;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface ITaskRepository
    {
        Task<int> CreateAsync(DAL.Entities.Task task);
        Task<bool> CheckIfExistAsync(string name);
        Task<Guid> GetUserIdAsync(string name);
        Task<Guid> GetProjectIdAsync(string name);
        Task<IEnumerable<DAL.Entities.Task>> GetAllAsync(Guid projectId, IPaging paging);
        Task<int> DeleteAsync(DAL.Entities.Task project);
        Task<DAL.Entities.Task> GetByIdAsync(Guid id);
    }
}
