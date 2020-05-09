using Model.Common.Base;
using System;
using System.Collections.Generic;

namespace Model.Common.ProjectManagement
{
    public interface IProjectModel : IBaseModel
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
