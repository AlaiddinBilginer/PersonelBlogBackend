using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreatePostCommandHandler(IPostWriteRepository postWriteRepository, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _postWriteRepository = postWriteRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            string? username = _contextAccessor?.HttpContext?.User?.Identity?.Name;
            ApplicationUser? applicationUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if(applicationUser == null)
            {
                return new CreatePostCommandErrorResponse() { Succeeded = false, Message = "Beklenmeyen bir hata ile karşılaşıldı!" };
            }

            await _postWriteRepository.AddAsync(new Post()
            {
                Id = id,
                ApplicationUserId = applicationUser.Id,
                Title = request.Title,
                Content = request.Content,
            });

            await _postWriteRepository.SaveAsync();

            return new CreatePostCommandSuccessResponse()
            {
                Id = id
            };
        }
    }
}
