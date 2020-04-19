using Model;
using AutoMapper;

namespace ProjectManagement.Models
{
    public class ControllerModule : Profile
    {
        public ControllerModule()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
        }
    }
}
