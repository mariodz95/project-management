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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementContext context;

        public ProjectRepository(ProjectManagementContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckIfExistAsync(string name)
        {
            var exist = await context.Project.AsNoTracking().AnyAsync(o => o.Name == name);
            return exist;
        }

        public async Task<int> CreateAsync(Project project)
        {
            await context.Project.AddAsync(project);
            var result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            var result = await context.Project.AsNoTracking().Include(up => up.UserProject).FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task<int> DeleteAsync(Project project)
        {
            context.Remove(project);
            var result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Project>> GetAllAsync(Guid userId, IPaging paging, IFiltering filtering/*, ISorting sortObj*/)
        {
            bool pagingEnabled = paging.PageSize > 0;
            IQueryable<Project> query = context.Project.Include(up => up.UserProject).ThenInclude(u => u.User);

            if (pagingEnabled)
            {
                paging.TotalPages = (int)Math.Ceiling((decimal)query.Count() / (decimal)paging.PageSize);
            }
            else
            {
                paging.TotalPages = 1;
            }

            if(filtering.FilterValue != null)
            {
                query = query.Where(p => p.Name == filtering.FilterValue);
            }

            if (pagingEnabled)
            {
                return await query.Skip((paging.PageNumber - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<int> UpdateAsync(Project project)
        {
            context.Update(project);
            return await context.SaveChangesAsync();
        }

        public async Task<int> AddUsersToProjectAsync(UserProject userProject)
        {
            await context.UserProject.AddAsync(userProject);
            return await context.SaveChangesAsync();
        }
    }
}
