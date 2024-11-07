using MediatR;

namespace PersonelBlogBackend.Application.Features.Tags.Queries.GetTags
{
    public class GetTagsQueryRequest : IRequest<GetTagsQueryResponse>
    {
        public short Count { get; set; }
    }
}
