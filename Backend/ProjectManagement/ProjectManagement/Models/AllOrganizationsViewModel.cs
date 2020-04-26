using ProjectManagement.Models.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class AllOrganizationsViewModel
    {
        public int TotalPages { get; set; }
        public IEnumerable<OrganizationViewModel> Organizations { get; set; }
    }
}
