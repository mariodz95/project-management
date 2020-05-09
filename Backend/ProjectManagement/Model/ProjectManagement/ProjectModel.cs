using Model.Common;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;

namespace Model.ProjectManagement
{
    public class ProjectModel : BaseModel, IProjectModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public IOrganizationModel Organization { get; set; }
        public IEnumerable<IUserModel> Users { get; set; }
        public IEnumerable<IUserProjectModel> UserProject { get; set; }
    }
}
