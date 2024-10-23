using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelBlogBackend.Application.Features.Posts.Commands.CreatePost;
using PersonelBlogBackend.Application.Features.Posts.Commands.DeletePost;
using PersonelBlogBackend.Application.Features.Posts.Commands.UpdatePost;
using PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost;
using PersonelBlogBackend.Application.Features.Posts.Queries.GetByIdPost;
using System.Net;

namespace PersonelBlogBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest getAllPostQueryRequest)
        {
            GetAllPostQueryResponse response = await _mediator.Send(getAllPostQueryRequest);
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            GetByIdPostQueryRequest request = new GetByIdPostQueryRequest();
            request.Id = id;

            GetByIdPostQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePostCommandRequest createPostCommandRequest)
        {
            CreatePostCommandResponse resnpose = await _mediator.Send(createPostCommandRequest);
            return Ok(resnpose);
        }

        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdatePostCommandRequest updatePostCommandRequest)
        {
            await _mediator.Send(updatePostCommandRequest);
            return Ok();
        }

        [HttpDelete("Delete")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            DeletePostCommandRequest request = new DeletePostCommandRequest();
            request.Id = id;

            await _mediator.Send(request);
            return Ok();
        }
    }
}
