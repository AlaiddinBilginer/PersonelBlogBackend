using MediatR;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommandRequest, AddCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;

        public AddCommentCommandHandler(ICommentWriteRepository commentWriteRepository)
        {
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<AddCommentCommandResponse> Handle(AddCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _commentWriteRepository.AddAsync(new Comment()
            {
                ApplicationUserId = request.ApplicationUserId,
                PostId = Guid.Parse(request.PostId),
                Content = request.Content,
            });
            await _commentWriteRepository.SaveAsync();

            return new AddCommentCommandResponse();
        }
    }
}
