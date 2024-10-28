using MediatR;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.AddComment
{
    public class AddCommentCommandRequest : IRequest<AddCommentCommandResponse>
    {
        public string ApplicationUserId { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}
