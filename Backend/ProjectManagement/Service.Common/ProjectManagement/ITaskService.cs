using Model.Common.ProjectManagement;
using System;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface ITaskService
    {
        Task<ITaskModel> CreateAsync(ITaskModel task);
    }
}
