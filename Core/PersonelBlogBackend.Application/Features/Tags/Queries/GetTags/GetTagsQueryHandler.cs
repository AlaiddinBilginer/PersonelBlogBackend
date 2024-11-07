using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.DTOs.Tags;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;

namespace PersonelBlogBackend.Application.Features.Tags.Queries.GetTags
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQueryRequest, GetTagsQueryResponse>
    {
        private readonly ITagReadRepository _tagReadRepository;

        public GetTagsQueryHandler(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;
        }

        public async Task<GetTagsQueryResponse> Handle(GetTagsQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TagDto> tags = _tagReadRepository.GetAll(false)
                .Take(request.Count)
                .Select(t => new TagDto()
                {
                    Id = t.Id,
                    Title = t.Title
                });

            return new GetTagsQueryResponse()
            {
                Success = true,
                Tags = tags
            };
        }
    }
}
