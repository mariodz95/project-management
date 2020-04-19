using System;

namespace DAL.Entities
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid UserId { get; set; }
    }
}
