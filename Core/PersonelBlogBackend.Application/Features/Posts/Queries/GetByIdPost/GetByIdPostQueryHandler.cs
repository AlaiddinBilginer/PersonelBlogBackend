using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonelBlogBackend.Application.DTOs.Comments;
using PersonelBlogBackend.Application.DTOs.PostImages;
using PersonelBlogBackend.Application.DTOs.Tags;
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
        private readonly IConfiguration _configuration;

        public GetByIdPostQueryHandler(IPostReadRepository postReadRepository, IConfiguration configuration)
        {
            _postReadRepository = postReadRepository;
            _configuration = configuration;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            var post = await _postReadRepository.Table
                .Where(p => p.Id == Guid.Parse(request.Id))
                .Include(p => p.Tags)
                .Include(p => p.PostImages)
                .Include(p => p.ApplicationUser)
                .Select(p => new GetByIdPostQueryResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    Tags = p.Tags.Select(t => new TagDto
                    {
                        Id = t.Id,
                        Title = t.Title
                    }).ToList(),
                    PostImages = p.PostImages.Select(pi => new PostImageDto
                    {
                        Path = _configuration["StorageUrls:LocalStorage"] + pi.Path
                    }).ToList(),
                    UserName = p.ApplicationUser.UserName,
                    FirstName = p.ApplicationUser.FirstName,
                    LastName = p.ApplicationUser.LastName,
                    ProfilePictureUrl = p.ApplicationUser.ProfilePictureUrl
                })
                .FirstOrDefaultAsync();

            return post;
        }

    }
}
