using MediatR;
using PersonelBlogBackend.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, DeletePostCommandResponse>
    {
        private readonly IPostWriteRepository _postWriteRepository;

        public DeletePostCommandHandler(IPostWriteRepository postWriteRepository)
        {
            _postWriteRepository = postWriteRepository;
        }

        public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _postWriteRepository.DeleteByIdAsync(request.Id);
            await _postWriteRepository.SaveAsync();

            return new DeletePostCommandResponse();
        }
    }
}
