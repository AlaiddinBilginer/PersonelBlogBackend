using PersonelBlogBackend.Application.DTOs.Comments;

namespace PersonelBlogBackend.Application.Features.Comments.Queries.GetAllByPostId
{
    public class GetAllByPostIdQueryResponse
    {
        public int TotalCommentCount { get; set; }
        public IQueryable<CommentListDto> Comments { get; set; }
    }
}
