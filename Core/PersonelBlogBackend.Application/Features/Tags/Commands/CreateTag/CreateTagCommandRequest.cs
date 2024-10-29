using MediatR;

namespace PersonelBlogBackend.Application.Features.Tags.Commands.CreateTag
{
    public class CreateTagCommandRequest : IRequest<CreateTagCommandResponse>
    {
        public string PostId { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
