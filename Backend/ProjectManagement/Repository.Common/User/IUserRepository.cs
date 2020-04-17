using DAL;
using System;
using System.Collections.Generic;

namespace Repository.Common.User
{
    public interface IUserRepository
    {
        DAL.Entities.User GetUser(string username);
        IEnumerable<DAL.Entities.User> GetAll();
        DAL.Entities.User GetById(Guid id);
        void Delete(Guid id);
        DAL.Entities.User Create(DAL.Entities.User user, string password);
        void Update(DAL.Entities.User userParam, string password = null);
    }
}
