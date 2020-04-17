using AutoMapper;
using DAL.Entities;
using Model.Common;

namespace Common.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, IUserModel>().ReverseMap();
            CreateMap<IRegisterModel, User>().ReverseMap();
            CreateMap<IUpdateModel, User>().ReverseMap();
        }
    }
}