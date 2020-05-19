using Model;
using AutoMapper;
using Model.Common;
using ProjectManagement.Models.ProjectManagement;
using Model.Common.ProjectManagement;

namespace ProjectManagement.Models
{
    public class ControllerModule : Profile
    {
        public ControllerModule()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<RegisterViewModel, IUserModel>().ReverseMap();
            CreateMap<UpdateViewModel, IUserModel>().ReverseMap();
            CreateMap<OrganizationViewModel, IOrganizationModel>().ReverseMap();
            CreateMap<ProjectViewModel, IProjectModel>().ReverseMap();
            CreateMap<UserViewModel, IUserModel>().ReverseMap();
            CreateMap<UserProjectViewModel, IUserProjectModel>().ReverseMap();
            CreateMap<ITaskModel, TaskViewModel>().ReverseMap();
        }
    }
}
