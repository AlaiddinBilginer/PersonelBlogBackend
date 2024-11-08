using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.DTOs.Comments;
using PersonelBlogBackend.Application.Repositories;

namespace PersonelBlogBackend.Application.Features.Comments.Queries.GetAllByPostId
{
    public class GetAllByPostIdQueryHandler : IRequestHandler<GetAllByPostIdQueryRequest, GetAllByPostIdQueryResponse>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetAllByPostIdQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<GetAllByPostIdQueryResponse> Handle(GetAllByPostIdQueryRequest request, CancellationToken cancellationToken)
        {
            int totalCommentCount = _commentReadRepository.GetWhere(c => c.PostId == Guid.Parse(request.PostId)).Count();

            IQueryable<CommentListDto> comments = _commentReadRepository.GetWhere(c => c.PostId == Guid.Parse(request.PostId))
                .OrderByDescending(c => c.CreatedDate)
                .Skip(request.Pagination.Page * request.Pagination.Size)
                .Take(request.Pagination.Size)
                .Include(c => c.ApplicationUser)
                .Select(c => new CommentListDto()
                {
                    Id = c.Id,
                    ApplicationUserId = c.ApplicationUserId,
                    Content = c.Content,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate,
                    UserName = c.ApplicationUser.UserName,
                    FirstName = c.ApplicationUser.FirstName,
                    LastName = c.ApplicationUser.LastName,
                    ProfilePictureUrl = c.ApplicationUser.ProfilePictureUrl,
                });

            return new GetAllByPostIdQueryResponse()
            {
                Comments = comments,
                TotalCommentCount = totalCommentCount
            };
        }
    }
}
