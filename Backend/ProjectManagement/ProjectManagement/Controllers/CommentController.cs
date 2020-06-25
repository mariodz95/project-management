using AutoMapper;
using Common.Helpers;
using DAL.Entities;
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
    public class CommentController : Controller
    {

        private ICommentService commentService;
        private IMapper mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CommentViewModel newComment)
        {
            try
            {
                var comment = mapper.Map<ICommentModel>(newComment);
                await commentService.CreateAsync(comment);
                return Ok(comment);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getall/{taskId}")]
        public async Task<IActionResult> GetAll(Guid taskId)
        {
            var comments = await commentService.GetAllAsync(taskId);

            return Ok(new { comments = mapper.Map<IEnumerable<CommentViewModel>>(comments)});
        }

    }
}
