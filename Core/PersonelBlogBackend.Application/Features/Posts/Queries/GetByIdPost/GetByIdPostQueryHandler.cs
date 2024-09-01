using MediatR;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetByIdPost
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetByIdPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            Post post = await _postReadRepository.GetByIdAsync(request.Id, false);

            return new GetByIdPostQueryResponse()
            {
                Id = post.Id,
                Comments = post.Comments,
                Content = post.Content,
                CreatedDate = post.CreatedDate,
                Tags = post.Tags,
                Title = post.Title,
                UpdatedDate = post.UpdatedDate
            };
        }
    }
}
