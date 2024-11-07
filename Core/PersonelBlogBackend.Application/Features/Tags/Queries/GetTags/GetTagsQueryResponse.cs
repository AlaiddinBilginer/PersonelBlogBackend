using PersonelBlogBackend.Application.DTOs.Tags;

namespace PersonelBlogBackend.Application.Features.Tags.Queries.GetTags
{
    public class GetTagsQueryResponse
    {
        public bool Success { get; set; }
        public IQueryable<TagDto> Tags { get; set; }
    }
}
