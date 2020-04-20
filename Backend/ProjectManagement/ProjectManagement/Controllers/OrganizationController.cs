using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using Common.Sort_Pag_Flt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Common.ProjectManagement;
using ProjectManagement.Models.ProjectManagement;
using Service.Common;
using Service.Common.ProjectManagement;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private IOrganizationService organizationService;
        private IMapper mapper;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            this.organizationService = organizationService;
            this.mapper = mapper;
        }

        [Authorize(Roles = Role.User)]
        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody]OrganizationViewModel organization, Guid userId)
        {
            try
            {
                var newOrganization = mapper.Map<IOrganizationModel>(organization);
                await organizationService.CreateAsync(userId, newOrganization);
                return Ok(newOrganization);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        protected override void Dispose(bool disposing)
        {
            organizationService.Dispose();
            base.Dispose(disposing);
        }

        [Authorize(Roles = Role.Organization)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize, int totalPages, string sort = null, string search = null, int? pageNumber = null)
        {
            IFiltering filtering = new Filtering
            {
                FilterValue = search
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

            var allOrganizations = await organizationService.GetAll(filtering, sorting, paging);
            return Ok(allOrganizations);
        }

    }
}
