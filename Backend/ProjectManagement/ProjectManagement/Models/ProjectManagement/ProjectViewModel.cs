using System;
using System.Collections.Generic;

namespace ProjectManagement.Models.ProjectManagement
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<UserProjectViewModel> UserProject { get; set; }
    }
}
