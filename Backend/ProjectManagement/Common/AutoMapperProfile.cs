﻿using AutoMapper;
using DAL.Entities;
using Model.Common;
using Model.Common.User;

namespace Common.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, IUserModel>().ReverseMap();
            CreateMap<UserRole, IUserRoleModel>().ReverseMap();
        }
    }
}