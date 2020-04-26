using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface IOrganizationService
    {
        Task<IOrganizationModel> CreateAsync(Guid userId, IOrganizationModel organization);
        Task<IEnumerable<IOrganizationModel>> GetAllAsync(Guid userId,IPaging paging);
    }
}
