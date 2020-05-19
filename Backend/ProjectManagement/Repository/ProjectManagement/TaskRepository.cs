using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common.ProjectManagement;
using System;
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
