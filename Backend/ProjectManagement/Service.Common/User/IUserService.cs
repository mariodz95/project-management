﻿using DAL.Entities;
using System;
using System.Collections.Generic;

namespace Service.Common
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(Guid id);
    }
}