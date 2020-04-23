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
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private IOrganizationService organizationService;
        private IMapper mapper;
        private Repository.Common.IUnitOfWork unitOfWork;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper, Repository.Common.IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.organizationService = organizationService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("organization/{id}")]
        public async Task<IActionResult> CreateOrganization(Guid id, [FromBody]OrganizationViewModel newOrganization)
        {
            try
            {
                var organization = mapper.Map<IOrganizationModel>(newOrganization);
                await organizationService.CreateAsync(id, organization);
                return Ok(newOrganization);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getall/{userId}")]
        public async Task<IActionResult> GetAll(int pageSize, int totalPages, string sort = null, string userId = null, int? pageNumber = null)
        {
            IFiltering filtering = new Filtering
            {
                FilterValue = userId
            };

            ISorting sorting = new Sorting
            {
                SortOrder = sort
            };

            IPaging paging = new Paging
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };


            var allOrganizations = await organizationService.GetAllAsync(filtering, sorting, paging);
            return Ok(allOrganizations);
        }


        //[AllowAnonymous]
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetOrganizationByZserId(Guid userId)
        //{
        //    try
        //    {
        //        var organization = await organizationService.GetOrganizationByUserIdAsync(userId);
        //        return Ok(organization);
        //    }
        //    catch (AppException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }

        //}
    }
}
