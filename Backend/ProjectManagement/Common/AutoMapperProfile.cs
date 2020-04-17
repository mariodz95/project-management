using AutoMapper;
using DAL.Entities.User;
using Model.Common;

namespace Common.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, IUserModel>();
            CreateMap<IRegisterModel, User>();
            CreateMap<IUpdateModel, User>();
        }
    }
}