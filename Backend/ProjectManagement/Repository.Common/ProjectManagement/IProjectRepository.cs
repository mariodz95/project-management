using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface IProjectRepository
    {
        Task<int> CreateAsync(Project project);
        Task<bool> CheckIfExistAsync(string name);
        Task<int> DeleteAsync(Project project);
        Task<Project> GetByIdAsync(Guid id);
        Task<IEnumerable<Project>> GetAllAsync(Guid userId, IPaging paging);
    }
}
