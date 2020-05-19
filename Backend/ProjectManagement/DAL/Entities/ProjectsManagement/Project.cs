using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public List<Task> Task { get; set; }
        public IEnumerable<UserProject> UserProject { get; set; }
    }
}
