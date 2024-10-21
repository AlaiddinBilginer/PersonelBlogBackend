using MediatR;
using Microsoft.AspNetCore.Http;

namespace PersonelBlogBackend.Application.Features.PostImages.Commands.UploadPostImage
{
    public class UploadPostImageCommandRequest : IRequest<UploadPostImageCommandResponse>
    {
        public string PostId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
