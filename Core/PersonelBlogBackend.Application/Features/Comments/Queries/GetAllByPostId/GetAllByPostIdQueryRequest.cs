using MediatR;
using PersonelBlogBackend.Application.RequestParameters;

namespace PersonelBlogBackend.Application.Features.Comments.Queries.GetAllByPostId
{
    public class GetAllByPostIdQueryRequest : IRequest<GetAllByPostIdQueryResponse>
    {
        public string PostId { get; set; }
        public Pagination? Pagination { get; set; } = new Pagination();
    }
}
