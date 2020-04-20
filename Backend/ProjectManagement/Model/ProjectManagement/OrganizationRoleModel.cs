using Model.Common;
using Model.Common.ProjectManagement;
using System;
using System.Collections.Generic;

namespace Model.ProjectManagement
{
    public class OrganizationRoleModel : BaseModel, IOrganizationRoleModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Description { get; set; }
        public List<IUserModel> User { get; set; }
        public Guid UserId { get; set; }
    }
}
