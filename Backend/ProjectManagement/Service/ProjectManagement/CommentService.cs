using AutoMapper;
using DAL.Entities;
using Model.Common.ProjectManagement;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProjectManagement
{
    public class CommentService : ICommentService
    {

        private ICommentRepository commentRepository;
        private IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        public async Task<ICommentModel> CreateAsync(ICommentModel newComment)
        {
            var comment = mapper.Map<Comment>(newComment);

            comment.Id = Guid.NewGuid();
            comment.DateCreated = DateTime.Now;
            comment.DateUpdated = DateTime.Now;

            await commentRepository.CreateAsync(comment);
            return mapper.Map<ICommentModel>(comment);
        }

        public async Task<IEnumerable<ICommentModel>> GetAllAsync(Guid taskId)
        {
            var comments = await commentRepository.GetAllAsync(taskId);
            return mapper.Map<IEnumerable<ICommentModel>>(comments);
        }
    }
}
