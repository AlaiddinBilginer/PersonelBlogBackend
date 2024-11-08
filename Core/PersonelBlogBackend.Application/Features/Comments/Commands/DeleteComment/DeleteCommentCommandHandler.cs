using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Domain.Entities.Identity;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteCommentCommandHandler(
            ICommentWriteRepository commentWriteRepository, 
            IHttpContextAccessor contextAccessor, 
            UserManager<ApplicationUser> userManager, 
            ICommentReadRepository commentReadRepository)
        {
            _commentWriteRepository = commentWriteRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _commentReadRepository = commentReadRepository;
        }

        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Comment comment = await _commentReadRepository.GetByIdAsync(request.Id);
            string? username = _contextAccessor?.HttpContext?.User?.Identity?.Name;

            ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null || user.Id != comment.ApplicationUserId)
            {
                return new DeleteCommentCommandResponse() { Succeeded = false, Message = "Kullanıcı bulunamadı veya bu yorumu silmek için yetki geçersiz" };
            }

            await _commentWriteRepository.DeleteByIdAsync(request.Id);
            await _commentWriteRepository.SaveAsync();
            return new DeleteCommentCommandResponse() { Succeeded = true, Message = "Yorum silme işlemi başarılı bir şekilde geerçekleşti"};
        }
    }
}
