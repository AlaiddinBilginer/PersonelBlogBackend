using MediatR;
using PersonelBlogBackend.Application.RequestParameters;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQueryRequest : IRequest<GetAllPostQueryResponse>
    {
        public Pagination? Pagination { get; set; } = new Pagination();
    }
}