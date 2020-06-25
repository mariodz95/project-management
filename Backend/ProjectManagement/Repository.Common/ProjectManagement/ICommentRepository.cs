using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common.ProjectManagement
{
    public interface ICommentRepository
    {
        Task<int> CreateAsync(Comment comment);
        Task<IEnumerable<Comment>> GetAllAsync(Guid taskId);
    }
}
