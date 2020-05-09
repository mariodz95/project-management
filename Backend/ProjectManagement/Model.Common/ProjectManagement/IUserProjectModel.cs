using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.ProjectManagement
{
    public interface IUserProjectModel
    {
        public Guid UserId { get; set; }
        public IUserModel User { get; set; }
        public Guid ProjectId { get; set; }
        public IProjectModel Project { get; set; }
    }
}
