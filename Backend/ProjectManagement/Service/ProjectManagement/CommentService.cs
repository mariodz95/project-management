using AutoMapper;
using Common.Helpers;
using DAL.Entities;
using Model.Common.ProjectManagement;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
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
            
            if(String.IsNullOrEmpty(comment.Text))
            {
                throw new AppException("Comment cannot be empty!");
            }

            comment.Id = Guid.NewGuid();
            comment.DateCreated = DateTime.Now;
            comment.DateUpdated = DateTime.Now;

            await commentRepository.CreateAsync(comment);
            return mapper.Map<ICommentModel>(comment);
        }

        public async Task<ICommentModel> DeleteAsync(Guid id)
        {
            var deletedComment = await commentRepository.DeleteAsync(id);
            return mapper.Map<ICommentModel>(deletedComment);
        }

        public async Task<IEnumerable<ICommentModel>> GetAllAsync(Guid taskId)
        {
            var comments = await commentRepository.GetAllAsync(taskId);
            return mapper.Map<IEnumerable<ICommentModel>>(comments);
        }

        public async Task<ICommentModel> UpdateAsync(Guid id, Comment updateComment)
        {
            var comment = await commentRepository.GetByIdAsync(id);

            if(String.IsNullOrEmpty(updateComment.Text))
            {
                throw new AppException("Comment cannot be empty!");
            }

            if (comment == null)
            {
                throw new AppException("Comment doesn't exist");
            }

            comment.Text = updateComment.Text;
            comment.DateUpdated = DateTime.Now;

            comment = await commentRepository.UpdateAsync(comment);
            return mapper.Map<ICommentModel>(comment);
        }
    }
}
