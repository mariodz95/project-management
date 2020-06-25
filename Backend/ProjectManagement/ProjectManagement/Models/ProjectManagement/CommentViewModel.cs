using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models.ProjectManagement
{
    public class CommentViewModel
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public string UserName { get; set; }
    }
}
