using MediatR;
using Microsoft.AspNetCore.Http;

namespace PersonelBlogBackend.Application.Features.PostImages.Commands.UploadPostImage
{
    public class UploadPostImageCommandRequest : IRequest<UploadPostImageCommandResponse>
    {
        public IFormFileCollection Files { get; set; }
    }
}
