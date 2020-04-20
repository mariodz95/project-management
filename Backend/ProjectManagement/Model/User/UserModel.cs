using Model.Common;
using Model.Common.ProjectManagement;
using Model.Common.User;
using Model.User;
using System;

namespace Model
{
    public class UserModel : IUserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public IUserRoleModel UserRole { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public IOrganizationRoleModel OrganizationRole { get; set; }
    }
}