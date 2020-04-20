using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Organization Organization { get; set; }
        public UserRole UserRole { get; set; }
        public ProjectRole ProjectRole { get; set; }
        public OrganizationRole OrganizationRole { get; set; }
        public List<Task> Task { get; set; }
        public List<UserProject> UserProject { get; set; }
    }
}