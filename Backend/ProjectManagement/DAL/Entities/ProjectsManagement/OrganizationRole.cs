using System.Collections.Generic;

namespace DAL.Entities
{
    public class OrganizationRole : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<User> User { get; set; }
    }
}
