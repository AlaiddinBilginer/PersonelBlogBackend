using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Domain.Entities.Identity;

namespace PersonelBlogBackend.Application.Features.Comments.Commands.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommandRequest, AddCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddCommentCommandHandler(ICommentWriteRepository commentWriteRepository, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _commentWriteRepository = commentWriteRepository;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<AddCommentCommandResponse> Handle(AddCommentCommandRequest request, CancellationToken cancellationToken)
        {
            string? username = _contextAccessor?.HttpContext?.User?.Identity?.Name;
            ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if(user == null)
            {
                return new AddCommentCommandResponse() { Succeeded = false, Message = "Kullanıcı bulunamadı"};
            }

            await _commentWriteRepository.AddAsync(new Comment()
            {
                ApplicationUserId = user.Id,
                PostId = Guid.Parse(request.PostId),
                Content = request.Content,
            });
            await _commentWriteRepository.SaveAsync();

            return new AddCommentCommandResponse() { Succeeded = true, Message = "Yorum ekleme işlemi başarılı bir şekilde gerçekleşti"};
        }
    }
}
