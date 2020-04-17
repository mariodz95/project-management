using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface IUserModel
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Username { get; set; }
    }
}
