using MediatR;
using PersonelBlogBackend.Application.Repositories;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;

        public DeleteCommentCommandHandler(ICommentWriteRepository commentWriteRepository)
        {
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _commentWriteRepository.DeleteByIdAsync(request.Id);
            await _commentWriteRepository.SaveAsync();
            return new DeleteCommentCommandResponse() { Succeeded = true, Message = "Yorum silme işlemi başarılı bir şekilde geerçekleşti"};
        }
    }
}
