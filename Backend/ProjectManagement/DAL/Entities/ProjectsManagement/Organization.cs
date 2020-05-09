using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public OrganizationRole OrganizationRole { get; set; }
        public IEnumerable<User> User { get; set; }
        public IEnumerable<Project> Project { get; set; }
    }
}
