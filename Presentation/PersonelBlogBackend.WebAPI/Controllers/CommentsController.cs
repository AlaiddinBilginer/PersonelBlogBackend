using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonelBlogBackend.Application.Features.Comments.Commands.AddComment;
using PersonelBlogBackend.Application.Features.Comments.Commands.DeleteComment;
using PersonelBlogBackend.Application.Features.Comments.Commands.UpdateComment;
using PersonelBlogBackend.Application.Features.Comments.Queries.GetAllByPostId;

namespace PersonelBlogBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllByPostId")]
        public async Task<IActionResult> GetAllByPostId([FromQuery]GetAllByPostIdQueryRequest request)
        {
            GetAllByPostIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddCommentCommandRequest request)
        {
            AddCommentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            DeleteCommentCommandRequest request = new DeleteCommentCommandRequest();
            request.Id = id;

            DeleteCommentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateCommentCommandRequest request)
        {
            UpdateCommentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
