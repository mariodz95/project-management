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
    public class CommentRepository : ICommentRepository
    {

        private readonly ProjectManagementContext context;

        public CommentRepository(ProjectManagementContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Comment comment)
        {
            await context.Comment.AddAsync(comment);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(Guid taskId)
        {
            return await context.Comment.AsNoTracking().Where(c => c.TaskId == taskId).ToListAsync();
        }
    }
}
