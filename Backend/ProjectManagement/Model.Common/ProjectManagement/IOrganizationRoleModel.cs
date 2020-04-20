using Model.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.ProjectManagement
{
    public interface IOrganizationRoleModel : IBaseModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

