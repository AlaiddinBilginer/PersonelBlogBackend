using PersonelBlogBackend.Domain.Entities;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQueryResponse
    {
        public int TotalCount { get; set; }
        public IQueryable<Post> Posts { get; set; }
    }
}