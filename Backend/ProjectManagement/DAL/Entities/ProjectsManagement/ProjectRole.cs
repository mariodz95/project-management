using System;

namespace DAL.Entities
{
    public class ProjectRole : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}
