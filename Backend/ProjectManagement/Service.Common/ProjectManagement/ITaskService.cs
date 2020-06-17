using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface ITaskService
    {
        Task<ITaskModel> CreateAsync(ITaskModel task);
        Task<IEnumerable<ITaskModel>> GetAllAsync(string projectName, IPaging paging);
        Task<int> DeleteAsync(Guid id);
    }
}
