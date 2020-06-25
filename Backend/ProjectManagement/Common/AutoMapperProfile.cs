using AutoMapper;
using DAL.Entities;
using Model.Common;
using Model.Common.ProjectManagement;
using Model.Common.User;

namespace Common.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, IUserModel>().ReverseMap();
            CreateMap<UserRole, IUserRoleModel>().ReverseMap();
            CreateMap<Organization, IOrganizationModel>().ReverseMap();
            CreateMap<OrganizationRole, IOrganizationRoleModel>().ReverseMap();
            CreateMap<Project, IProjectModel>().ReverseMap();
            CreateMap<UserProject, IUserProjectModel>().ReverseMap();
            CreateMap<ITaskModel, DAL.Entities.Task>().ReverseMap();
            CreateMap<Comment, ICommentModel>().ReverseMap();
        }
    }
}