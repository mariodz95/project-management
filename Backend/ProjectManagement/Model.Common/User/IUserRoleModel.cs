using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.User
{
    public interface IUserRoleModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid UserId { get; set; }
    }
}
