using Model.Common.ProjectManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common.ProjectManagement
{
    public interface ICommentService
    {
        Task<ICommentModel> CreateAsync(ICommentModel newComment);
        Task<IEnumerable<ICommentModel>> GetAllAsync(Guid taskId);
    }
}
