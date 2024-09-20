using MediatR;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Application.DTOs.Auth;

namespace PersonelBlogBackend.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.RegisterAsync(new RegisterRequest()
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword
            });

            return new RegisterUserCommandResponse() { Succeeded = response.Succeeded, Message = response.Message };
        }
    }
}
