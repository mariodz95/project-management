using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using Common.Sort_Pag_Flt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Common.ProjectManagement;
using ProjectManagement.Models;
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
    public class OrganizationController : Controller
    {
        private IOrganizationService organizationService;
        private IMapper mapper;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
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
        [HttpGet("getall/{userId}&{pageNumber}&{pageSize}")]
        public async Task<IActionResult> GetAll(Guid userId, int pageNumber = 0, int pageSize = 10) 
        {
            IPaging paging = new Paging
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = 0
            };

            var allOrganizations = await organizationService.GetAllAsync(userId, paging);

            return Ok(new { organizations = mapper.Map<IEnumerable<OrganizationViewModel>>(allOrganizations), totalPages = paging.TotalPages });
        }
    }
}
