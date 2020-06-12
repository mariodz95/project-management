using Common.Interface_Sort_Pag_Flt;
using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ProjectManagement
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ProjectManagementContext context;

        public TaskRepository(ProjectManagementContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckIfExistAsync(string name)
        {
            return await context.Task.AsNoTracking().AnyAsync(o => o.Name == name);
        }

        public async Task<int> CreateAsync(DAL.Entities.Task task)
        {
            await context.Task.AddAsync(task);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DAL.Entities.Task>> GetAllAsync(Guid projectId, IPaging paging)
        {
            bool pagingEnabled = paging.PageSize > 0;
            var query = context.Task;

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

        public async Task<Guid> GetProjectIdAsync(string name)
        {
            var project = await context.Project.AsNoTracking().FirstOrDefaultAsync(t => t.Name == name);
            return project.Id;
        }

        public async Task<Guid> GetUserIdAsync(string name)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == name);
            return user.Id;
        }
    }
}
