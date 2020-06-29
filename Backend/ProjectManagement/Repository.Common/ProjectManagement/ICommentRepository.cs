using DAL.Entities;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface ICommentRepository
    {
        Task<int> CreateAsync(Comment comment);
        Task<IEnumerable<Comment>> GetAllAsync(Guid taskId);
        Task<Comment> DeleteAsync(Guid id);
        Task<Comment> GetByIdAsync(Guid id);
        Task<Comment> UpdateAsync(Comment comment);
    }
}
