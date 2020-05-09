using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Service.Common;
using System;
using Common.Helpers;
using Model;
using System.Threading.Tasks;
using ProjectManagement;
using Common.Interface_Sort_Pag_Flt;
using Common.Sort_Pag_Flt;
using Model.Common;
using AutoMapper;
using ProjectManagement.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUserService userService;
        private IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateViewModel model)
        {
            var user = await userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenString = userService.GetToken(user);

            //TODO user roles
            var userModel = new UserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Role = user.UserRole.Abrv,
                Token = tokenString
            };

            return Ok(userModel);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            try
            {
                var user = mapper.Map<IUserModel>(model);
                await userService.CreateAsync(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [AllowAnonymous]
        [HttpGet("getall/{organizationId}")]
        public async Task<IActionResult> GetAll(Guid organizationId)
        {
            try
            {
                var users = await userService.GetAll(organizationId);
                return Ok(users);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await userService.GetByIdAsync(id);
            return Ok(user);
        }
    }
}