using MediatR;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Application.DTOs;
using PersonelBlogBackend.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly IAuthService _authService;

        public RefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            AuthResponse response = await _authService.RefreshAccessTokenAsync(request.RefreshToken);

            if (response.Succeeded)
            {
                return new RefreshTokenCommandSuccessResponse { Succeeded = response.Succeeded, Token = response.Token };
            }
            else
            {
                return new RefreshTokenCommandErrorResponse { Succeeded = response.Succeeded, Message = response.Message };
            }
        }
    }
}
