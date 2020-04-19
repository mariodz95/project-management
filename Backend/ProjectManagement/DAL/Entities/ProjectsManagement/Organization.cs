using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Description { get; set; }
        public List<User> User { get; set; }
        public List<Project> Project { get; set; }
        public Guid UserId { get; set; }
    }
}
