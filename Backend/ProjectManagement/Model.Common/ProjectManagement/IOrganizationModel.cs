using Model.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.ProjectManagement
{
    public interface IOrganizationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int TotalPages { get; set; }
        public IOrganizationRoleModel OrganizationRole { get; set; }
        public IEnumerable<IUserModel> User { get; set; }
        public Guid UserId { get; set; }
    }
}
