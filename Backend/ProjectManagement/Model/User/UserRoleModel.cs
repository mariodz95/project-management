using Model.Common.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
    public class UserRoleModel : IUserRoleModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid UserId { get; set; }
    }
}
