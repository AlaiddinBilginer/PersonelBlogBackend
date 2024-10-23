using PersonelBlogBackend.Application.DTOs.Posts;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQueryResponse
    {
        public int TotalCount { get; set; }
        public IQueryable<PostDto> Posts { get; set; }
    }
}