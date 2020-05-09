using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Common;
using Model.Common.ProjectManagement;
using Repository.Common;
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
        private IUserRepository userRepository;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper, IUserRepository userRepository)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
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

            UserProject userProject = new UserProject();
            foreach (var item in project.Users) {
                var user = await userRepository.GetByIdAsync(item.Id);
                userProject.ProjectId = newProject.Id;
                userProject.UserId = item.Id;
                userProject.Project = newProject;
                await projectRepository.AddUsersToProjectAsync(userProject);
            }
            return mapper.Map<IProjectModel>(newProject);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            return await projectRepository.DeleteAsync(project);
        }

        public async Task<IEnumerable<IProjectModel>> GetAllAsync(Guid userId, IPaging paging, IFiltering filtering)
        {
            var projects = await projectRepository.GetAllAsync(userId, paging, filtering);
            var mapList = mapper.Map<IEnumerable<IProjectModel>>(projects);
            return mapList; 
        }

        public async Task<int> UpdateAsync(Guid id, IProjectModel project)
        {
            var existingProject = await projectRepository.GetByIdAsync(id);
            
            if (existingProject == null)
            {
                throw new AppException("Project name \"" + project.Name + "\" doesnt exist");
            }

            existingProject.Name = project.Name;
            existingProject.DateUpdated = DateTime.Now;
            existingProject.Abrv = project.Name.ToLower();
            existingProject.Description = project.Description;
            var result = await projectRepository.UpdateAsync(existingProject);
            return result; 
        }
    }
}
