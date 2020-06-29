using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.ProjectManagement
{
    public interface ICommentModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public string UserName { get; set; }
    }
}
