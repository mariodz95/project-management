using Model.Common.ProjectManagement;
using System;

namespace Model.ProjectManagement
{
    public class ProjectModel : BaseModel, IProjectModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public IOrganizationModel Organization { get; set; }
    }
}
