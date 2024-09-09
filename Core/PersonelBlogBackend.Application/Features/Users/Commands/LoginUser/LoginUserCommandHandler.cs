using MediatR;
using Microsoft.AspNetCore.Identity;
using PersonelBlogBackend.Application.Abstractions;
using PersonelBlogBackend.Application.DTOs;
using PersonelBlogBackend.Domain.Entities.Identity;

namespace PersonelBlogBackend.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(request.EmailOrUsername);

            if (user == null)
                user = await _userManager.FindByEmailAsync(request.EmailOrUsername);

            if (user == null)
                return new LoginUserErrorCommandResponse()
                {
                    Message = "Kullanıcı adı veya e-posta hatalıdır"
                };

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(60);

                return new LoginUserSuccessCommandResponse()
                {
                    Token = token,
                };
            }

            return new LoginUserErrorCommandResponse()
            {
                Message = "Hatalı şifre girdiniz"
            };
        }
    }
}
