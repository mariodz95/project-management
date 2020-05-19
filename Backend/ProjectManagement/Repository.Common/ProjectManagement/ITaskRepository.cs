using System;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface ITaskRepository
    {
        Task<int> CreateAsync(DAL.Entities.Task task);
        Task<bool> CheckIfExistAsync(string name);
        Task<Guid> GetUserIdAsync(string name);
        Task<Guid> GetProjectIdAsync(string name);
    }
}
