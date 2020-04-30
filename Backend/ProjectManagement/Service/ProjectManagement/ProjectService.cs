using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Model.Common.ProjectManagement;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.ProjectManagement
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository projectRepository;
        private IMapper mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<IProjectModel> CreateAsync(Guid userId, IProjectModel project)
        {
            var newProject = mapper.Map<Project>(project);

            if (string.IsNullOrWhiteSpace(newProject.Name))
            {
                throw new AppException("Project name is required");
            }

            if (await projectRepository.CheckIfExistAsync(newProject.Name))
            {
                throw new AppException("Project name \"" + newProject.Name + "\" is already taken");
            }

            newProject.Id = Guid.NewGuid();
            newProject.Abrv = project.Name.ToLower();
            newProject.DateCreated = DateTime.Now;
            newProject.DateUpdated = DateTime.Now;
            newProject.OwnerId = userId;
            newProject.OrganizationId = Guid.Parse("EFAD2DBD-15F3-4EFA-8B83-2997C3C06697");
            //TODO project role
            //var organizationRole = new OrganizationRole
            //{
            //    Id = Guid.NewGuid(),
            //    DateUpdated = DateTime.Now,
            //    DateCreated = DateTime.Now,
            //    Name = Role.User,
            //    Abrv = Role.User,
            //    UserId = userId,
            //    OrganizationId = newOrganization.Id,
            //};

            //newOrganization.OrganizationRole = organizationRole;
            await projectRepository.CreateAsync(newProject);
            return mapper.Map<IProjectModel>(newProject);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            var result = await projectRepository.DeleteAsync(project);
            return result;
        }

        public async Task<IEnumerable<IProjectModel>> GetAllAsync(Guid userId, IPaging paging)
        {

            var projects = await projectRepository.GetAllAsync(userId, paging);
            return mapper.Map<IEnumerable<IProjectModel>>(projects);
        }
    }
}
