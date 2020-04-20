using Model;
using AutoMapper;
using Model.Common;

namespace ProjectManagement.Models
{
    public class ControllerModule : Profile
    {
        public ControllerModule()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<RegisterViewModel, IUserModel>().ReverseMap();
            CreateMap<UpdateViewModel, IUserModel>().ReverseMap();
        }
    }
}
