using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface IOrganizationRepositroy  
    {
        Task<IOrganizationModel> CreateAsync(Guid userId, IOrganizationModel organization);
        Task<IEnumerable<IOrganizationModel>> GetAllAsync(IFiltering filterObj, ISorting sortObj, IPaging pagingObj);
        Task<bool> DeleteAsync(Guid id);

        //Task<IOrganizationModel> GetOrganizationByUserIdAsync(Guid userId);
    }
}
