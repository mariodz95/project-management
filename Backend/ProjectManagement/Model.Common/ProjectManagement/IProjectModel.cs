using Model.Common.Base;
using System;


namespace Model.Common.ProjectManagement
{
    public interface IProjectModel : IBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public IOrganizationModel Organization { get; set; }
    }
}
