using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Domain.Entities.Identity;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateCommentCommandHandler(
            ICommentWriteRepository commentWriteRepository, 
            ICommentReadRepository commentReadRepository, 
            IHttpContextAccessor contextAccessor, 
            UserManager<ApplicationUser> userManager)
        {
            _commentWriteRepository = commentWriteRepository;
            _commentReadRepository = commentReadRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Comment comment = await _commentReadRepository.GetByIdAsync(request.CommentId);
            string? username = _contextAccessor?.HttpContext?.User?.Identity?.Name;

            ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if(comment != null && user != null && user.Id == comment.ApplicationUserId)
            {
                comment.Content = request.Content;
                await _commentWriteRepository.SaveAsync();
                return new UpdateCommentCommandResponse()
                {
                    Succeeded = true,
                    Message = "Yorumunuz başarılı bir şekilde güncellendi"
                };
            }

            return new UpdateCommentCommandResponse()
            {
                Succeeded = false,
                Message = "Yorumunuz güncellenirken bir hata ile karşılaşıldı!"
            };
        }
    }
}
