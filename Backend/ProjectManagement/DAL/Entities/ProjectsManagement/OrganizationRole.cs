using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class OrganizationRole : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public List<User> User { get; set; }
    }
}
