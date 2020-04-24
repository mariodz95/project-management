using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface IOrganizationRepositroy  
    {
        Task<int> CreateAsync(Organization organization);
        Task<IEnumerable<Organization>> GetAllAsync(Guid userId, IPaging paging);
        Task<bool> CheckIfExistAsync(string name);
    }
}
