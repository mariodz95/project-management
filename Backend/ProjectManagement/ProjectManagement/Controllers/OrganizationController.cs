using AutoMapper;
using Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Common.ProjectManagement;
using ProjectManagement.Models.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections;
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
        [HttpGet("getall/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, int pageSize = 10, int totalPages = 1, int? pageNumber = 1)
        {
            var allOrganizations = await organizationService.GetAllAsync(userId, pageSize, totalPages, pageNumber);
            return Ok(mapper.Map<IEnumerable<OrganizationViewModel>>(allOrganizations));
        }
    }
}
