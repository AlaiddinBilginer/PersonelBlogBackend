using PersonelBlogBackend.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Abstractions.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request, int accessTokenLifetime);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}
