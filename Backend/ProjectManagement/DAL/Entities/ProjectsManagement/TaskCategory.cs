using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class TaskCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Task> Task { get; set; }
    }
}
