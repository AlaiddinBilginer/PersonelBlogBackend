using MediatR;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public UpdatePostCommandHandler(IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository)
        {
            _postWriteRepository = postWriteRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Post post = await _postReadRepository.GetByIdAsync(request.Id);
            post.Title = request.Title;
            post.Content = request.Content;

            await _postWriteRepository.SaveAsync();

            return new UpdatePostCommandResponse();
        }
    }
}
