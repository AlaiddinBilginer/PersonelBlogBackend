using MediatR;
using PersonelBlogBackend.Application.Repositories;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, GetAllPostQueryResponse>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetAllPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<GetAllPostQueryResponse> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)   
        {
            int totalCount = _postReadRepository.GetAll().Count();

            var posts = _postReadRepository.GetAll(false)
                .Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size);

            return new GetAllPostQueryResponse
            {
                TotalCount = totalCount,
                Posts = posts
            };
        }
    }
}