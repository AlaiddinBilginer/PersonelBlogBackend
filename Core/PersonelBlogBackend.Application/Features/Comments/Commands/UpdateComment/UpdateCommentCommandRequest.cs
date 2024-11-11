using MediatR;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
    {
        public string CommentId { get; set; }
        public string Content { get; set; }
    }
}
