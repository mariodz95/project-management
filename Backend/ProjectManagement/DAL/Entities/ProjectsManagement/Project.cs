using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<TaskCategory> TaskCategory { get; set; }
        public List<Task> Task { get; set; }
        public List<UserProject> UserProject { get; set; }
    }
}
