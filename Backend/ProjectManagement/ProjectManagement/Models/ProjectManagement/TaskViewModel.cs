

using System;

namespace ProjectManagement.Models.ProjectManagement
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Estimated { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedOn { get; set; }
        public string ProjectName { get; set; }
    }
}
