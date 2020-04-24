using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ProjectManagement
{
    public class OrganizationRepository : IOrganizationRepositroy
    {

        private readonly ProjectManagementContext context;

        public OrganizationRepository(ProjectManagementContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckIfExistAsync(string name)
        {
            var exist = await context.Organization.AnyAsync(o => o.Name == name);
            return exist;
        }

        public async Task<int> CreateAsync(Organization organization)
        {       
            await context.Organization.AddAsync(organization);
            var result = await context.SaveChangesAsync();
            return result;  
        }

        public async Task<IEnumerable<Organization>> GetAllAsync(Guid userId)
        {
            return await context.Organization.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
