using DAL.Entities.User;
using System.Collections.Generic;

namespace Service.Common
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
