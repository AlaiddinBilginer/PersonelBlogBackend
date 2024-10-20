using MediatR;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        private readonly IPostWriteRepository _postWriteRepository;

        public CreatePostCommandHandler(IPostWriteRepository postWriteRepository)
        {
            _postWriteRepository = postWriteRepository;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();

            await _postWriteRepository.AddAsync(new Post()
            {
                Id = id,
                Title = request.Title,
                Content = request.Content,
            });

            await _postWriteRepository.SaveAsync();

            return new CreatePostCommandResponse()
            {
                Id = id
            };
        }
    }
}
