using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using Common.Sort_Pag_Flt;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Common.ProjectManagement;
using ProjectManagement.Models.ProjectManagement;
using Service.Common.ProjectManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {

        private ITaskService taskService;
        private IMapper mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskViewModel newTask)
        {
            try
            {
                var task = mapper.Map<ITaskModel>(newTask);
                await taskService.CreateAsync(task);
                return Ok(task);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getall/{projectName}&{pageNumber}&{pageSize}")]
        public async Task<IActionResult> GetAll(string projectName, int pageNumber = 0, int pageSize = 10)
        {
            IPaging paging = new Paging
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = 0
            };

            var tasks = await taskService.GetAllAsync(projectName, paging);

            return Ok(new { tasks = mapper.Map<IEnumerable<TaskViewModel>>(tasks), totalPages = paging.TotalPages });
        }

        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(System.Guid id)
        {
            try
            {
                await taskService.DeleteAsync(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
