using Model.Common;
using Model.Common.ProjectManagement;
using System;


namespace Model.ProjectManagement
{
    public class UserProjectModel : IUserProjectModel
    {
        public Guid UserId { get; set; }
        public IUserModel User { get; set; }
        public Guid ProjectId { get; set; }
        public IProjectModel Project { get; set; }
    }
}
