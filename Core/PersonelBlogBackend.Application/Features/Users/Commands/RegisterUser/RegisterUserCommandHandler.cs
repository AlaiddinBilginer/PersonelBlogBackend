using MediatR;
using Microsoft.AspNetCore.Identity;
using PersonelBlogBackend.Domain.Entities.Identity;

namespace PersonelBlogBackend.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                UserName = request.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            RegisterUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded && (request.Password == request.ConfirmPassword))
                response.Message = "Kayıt işlemi başarıyla gerçekleştirilmiştir";
            else
                response.Message = "Kayıt işlemi başarısız olmuştur";

            return response;
        }
    }
}
