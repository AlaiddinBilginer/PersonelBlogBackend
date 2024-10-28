using MediatR;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandRequest : IRequest<DeleteCommentCommandResponse>
    {
        public string Id { get; set; }
    }
}
