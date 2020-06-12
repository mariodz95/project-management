using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.ProjectManagement
{
    public class TaskService : ITaskService
    {

        private ITaskRepository taskRepository;
        private IMapper mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        public async Task<ITaskModel> CreateAsync(ITaskModel task)
        {
            var newTask = mapper.Map<DAL.Entities.Task>(task);

            if (string.IsNullOrWhiteSpace(newTask.Name))
            {
                throw new AppException("Task name is required");
            }

            if (await taskRepository.CheckIfExistAsync(newTask.Name))
            {
                throw new AppException("Task name \"" + newTask.Name + "\" is already taken");
            }

            var projectId = await taskRepository.GetProjectIdAsync(task.ProjectName);

            if (projectId == null)
            {
                throw new AppException("Project doesn't exist\"" + task.ProjectName);
            }

            var userId = await taskRepository.GetUserIdAsync(task.AssignedOn); 

            if(userId == null)
            {
                throw new AppException("User doesn't exist\"" + task.AssignedOn);
            }

            newTask.Id = Guid.NewGuid();
            newTask.Abrv = task.Name.ToLower();
            newTask.DateCreated = DateTime.Now;
            newTask.DateUpdated = DateTime.Now;
            newTask.ProjectId = projectId;
            newTask.UserId = userId;

            await taskRepository.CreateAsync(newTask);
            return mapper.Map<ITaskModel>(newTask);
        }

        public async Task<IEnumerable<ITaskModel>> GetAllAsync(string projectName, IPaging paging)
        {
            var projectId = await taskRepository.GetProjectIdAsync(projectName);
            var tasks = await taskRepository.GetAllAsync(projectId, paging);
            return mapper.Map<IEnumerable<ITaskModel>>(tasks);
        }
    }
}
