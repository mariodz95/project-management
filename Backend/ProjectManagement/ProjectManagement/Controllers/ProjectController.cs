using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using Common.Sort_Pag_Flt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Common.ProjectManagement;
using ProjectManagement.Models.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private IProjectService projectService;
        private IMapper mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create/{id}")]
        public async Task<IActionResult> CreateProject(Guid id, [FromBody]ProjectViewModel newProject)
        {
            try
            {
                var project = mapper.Map<IProjectModel>(newProject);
                await projectService.CreateAsync(id, project);
                return Ok(project);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            try
            {
                await projectService.DeleteAsync(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getall/{userId}&{pageNumber}&{pageSize}/{search?}")]
        public async Task<IActionResult> GetAll(Guid userId, int pageNumber = 0, int pageSize = 10, string? search = null/*, string sort = null*/)
        {
            IFiltering filtering = new Filtering
            {
                FilterValue = search
            };

            //ISorting sorting = new Sorting
            //{
            //    SortOrder = sort
            //};

            IPaging paging = new Paging
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = 0
            };

            var allProjects = await projectService.GetAllAsync(userId, paging, filtering);
            var mapProjects = mapper.Map<IEnumerable<ProjectViewModel>>(allProjects);
            return Ok(new { projects = mapProjects, totalPages = paging.TotalPages });
        }

        [AllowAnonymous]
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]ProjectViewModel newProject)
        {
            try
            {
                var project = mapper.Map<IProjectModel>(newProject);
                await projectService.UpdateAsync(id, project);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
