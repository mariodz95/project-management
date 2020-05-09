using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models.ProjectManagement
{
    public class UserProjectViewModel
    {
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
