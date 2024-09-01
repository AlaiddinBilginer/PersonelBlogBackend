using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelBlogBackend.Application.Features.Posts.Commands.CreatePost;
using PersonelBlogBackend.Application.Features.Posts.Commands.DeletePost;
using PersonelBlogBackend.Application.Features.Posts.Commands.UpdatePost;
using PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost;
using PersonelBlogBackend.Application.Features.Posts.Queries.GetByIdPost;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Application.ViewModels.Posts;
using PersonelBlogBackend.Domain.Entities;
using System.Net;

namespace PersonelBlogBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IMediator _mediator;

        public PostsController(
            IPostReadRepository postReadRepository, 
            IPostWriteRepository postWriteRepository,
            IMediator mediator
        )
        {
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest getAllPostQueryRequest)
        {
            GetAllPostQueryResponse response = await _mediator.Send(getAllPostQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPostQueryRequest getByIdPostQueryRequest)
        {
            GetByIdPostQueryResponse response = await _mediator.Send(getByIdPostQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostCommandRequest createPostCommandRequest)
        {
            await _mediator.Send(createPostCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePostCommandRequest updatePostCommandRequest)
        {
            await _mediator.Send(updatePostCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePostCommandRequest deletePostCommandRequest)
        {
            await _mediator.Send(deletePostCommandRequest);
            return Ok();
        }
    }
}
