using MediatR;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}
