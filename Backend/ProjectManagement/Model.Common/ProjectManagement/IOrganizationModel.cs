using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.ProjectManagement
{
    public interface IOrganizationModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Description { get; set; }
        public IOrganizationRoleModel OrganizationRole { get; set; }
        public List<IUserModel> User { get; set; }
        public Guid UserId { get; set; }
    }
}
