using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelBlogBackend.Application.Features.Tags.Commands.CreateTag;
using PersonelBlogBackend.Application.Features.Tags.Queries.GetTags;

namespace PersonelBlogBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateTags")]
        public async Task<IActionResult> CreateTags([FromBody]CreateTagCommandRequest request)
        {
            CreateTagCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetTags")]
        public async Task<IActionResult> GetTags([FromQuery]GetTagsQueryRequest request)
        {
            GetTagsQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
