
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonelBlogBackend.Application.Features.PostImages.Commands.UploadPostImage;
using PersonelBlogBackend.Application.Repositories;

namespace PersonelBlogBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm]UploadPostImageCommandRequest request)
        {
            UploadPostImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
