using MediatR;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Application.DTOs.Auth;

namespace PersonelBlogBackend.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle
            (LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(new LoginRequest()
            {
                EmailOrUsername = request.EmailOrUsername,
                Password = request.Password
            }, 120);

            if (response.Succeeded)
                return new LoginUserSuccessCommandResponse { Succeeded = response.Succeeded, Token = response.Token };

            return new LoginUserErrorCommandResponse { Succeeded = response.Succeeded, Message = response.Message };
        }
    }
}
