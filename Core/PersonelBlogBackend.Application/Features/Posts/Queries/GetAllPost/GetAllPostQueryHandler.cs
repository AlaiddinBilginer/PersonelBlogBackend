using MediatR;
using Microsoft.EntityFrameworkCore;
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
            int totalCount = _postReadRepository.GetAll()
                .Where(p => string.IsNullOrEmpty(request.TagTitle) || p.Tags.Any(tag => tag.Title == request.TagTitle))
                .Count();

            var posts = _postReadRepository.GetAll(false)
                .Where(p => string.IsNullOrEmpty(request.TagTitle) || p.Tags.Any(tag => tag.Title == request.TagTitle))
                .OrderByDescending(p => p.CreatedDate)
                .Skip(request.Pagination.Page * request.Pagination.Size)
                .Take(request.Pagination.Size)
                .Include(p => p.ApplicationUser)
                .Select(p => new PostDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    FirstImage = p.PostImages.FirstOrDefault() != null ? _configuration["StorageUrls:LocalStorage"] + p.PostImages.FirstOrDefault().Path : null,
                    CreatedDate = p.CreatedDate,
                    ApplicationUserId = p.ApplicationUserId,
                    UserName = p.ApplicationUser.UserName,
                    FirstName = p.ApplicationUser.FirstName,
                    LastName = p.ApplicationUser.LastName
                });

            return new GetAllPostQueryResponse
            {
                TotalCount = totalCount,
                Posts = posts
            };
        }
    }
}