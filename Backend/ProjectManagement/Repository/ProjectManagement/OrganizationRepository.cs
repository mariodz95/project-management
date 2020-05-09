using Common.Interface_Sort_Pag_Flt;
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
            var exist = await context.Organization.AsNoTracking().AnyAsync(o => o.Name == name);
            return exist;
        }

        public async Task<int> CreateAsync(Organization organization)
        {
            await context.Organization.AddAsync(organization);
            var result = await context.SaveChangesAsync();
            return result;  
        }

        public async Task<IEnumerable<Organization>> GetAllAsync(Guid userId, IPaging paging)
        {
            bool pagingEnabled = paging.PageSize > 0;
            var query = context.Organization;

            if (pagingEnabled)
            {
                paging.TotalPages = (int)Math.Ceiling((decimal)query.Count() / (decimal)paging.PageSize);
            }
            else
            {
                paging.TotalPages = 1;
            }

            if (pagingEnabled)
            {
                return await query.Skip((paging.PageNumber - 1) * paging.PageSize).Take(paging.PageSize).AsNoTracking().ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }
    }
}
