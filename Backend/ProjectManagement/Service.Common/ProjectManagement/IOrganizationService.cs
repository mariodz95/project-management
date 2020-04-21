using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface IOrganizationService
    {
        Task<IOrganizationModel> CreateAsync(Guid userId, IOrganizationModel organization);
        Task<List<IOrganizationModel>> GetAll();
        //Task<IOrganizationModel> GetOrganizationByUserIdAsync(Guid userId);
    }
}
