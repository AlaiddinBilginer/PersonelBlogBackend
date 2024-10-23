using MediatR;
using Microsoft.Extensions.Configuration;
using PersonelBlogBackend.Application.DTOs.Posts;
using PersonelBlogBackend.Application.Repositories;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, GetAllPostQueryResponse>
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IConfiguration _configuration;
        public GetAllPostQueryHandler(IPostReadRepository postReadRepository, IConfiguration configuration)
        {
            _postReadRepository = postReadRepository;
            _configuration = configuration;
        }

        public async Task<GetAllPostQueryResponse> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)   
        {
            int totalCount = _postReadRepository.GetAll().Count();

            var posts = _postReadRepository.GetAll(false)
                .OrderByDescending(p => p.CreatedDate)
                .Skip(request.Pagination.Page * request.Pagination.Size)
                .Take(request.Pagination.Size)
                .Select(p => new PostDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    FirstImage = p.PostImages.FirstOrDefault() != null ? _configuration["StorageUrls:LocalStorage"] + p.PostImages.FirstOrDefault().Path : null,
                    CreatedDate = p.CreatedDate
                });

            return new GetAllPostQueryResponse
            {
                TotalCount = totalCount,
                Posts = posts
            };
        }
    }
}