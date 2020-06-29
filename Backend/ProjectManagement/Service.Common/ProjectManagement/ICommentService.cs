using DAL.Entities;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface ICommentService
    {
        Task<ICommentModel> CreateAsync(ICommentModel newComment);
        Task<IEnumerable<ICommentModel>> GetAllAsync(Guid taskId);
        Task<ICommentModel> DeleteAsync(Guid id);
        Task<ICommentModel> UpdateAsync(Guid id, Comment comment);
    }
}
