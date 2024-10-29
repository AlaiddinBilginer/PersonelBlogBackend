using MediatR;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;

        public UpdateCommentCommandHandler(ICommentWriteRepository commentWriteRepository, ICommentReadRepository commentReadRepository)
        {
            _commentWriteRepository = commentWriteRepository;
            _commentReadRepository = commentReadRepository;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Comment comment = await _commentReadRepository.GetByIdAsync(request.CommentId);
            if(comment != null && comment.ApplicationUserId == request.ApplicationUserId)
            {
                comment.Content = request.Content;
                await _commentWriteRepository.SaveAsync();
                return new UpdateCommentCommandResponse()
                {
                    Succeeded = true,
                    Message = "Yorumunuz başarılı bir şekilde güncellendi"
                };
            }

            return new UpdateCommentCommandResponse()
            {
                Succeeded = false,
                Message = "Yorumunuz güncellenirken bir hata ile karşılaşıldı!"
            };
        }
    }
}
