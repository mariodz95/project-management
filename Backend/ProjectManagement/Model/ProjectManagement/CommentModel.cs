using Model.Common.ProjectManagement;
using System;

namespace Model.ProjectManagement
{
    public class CommentModel : ICommentModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
