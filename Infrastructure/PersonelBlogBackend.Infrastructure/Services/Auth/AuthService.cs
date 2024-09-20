using Microsoft.AspNetCore.Identity;
using PersonelBlogBackend.Application.Abstractions;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Application.DTOs;
using PersonelBlogBackend.Application.DTOs.Auth;
using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request, int accessTokenLifetime)
        {
            var user = await _userManager.FindByNameAsync(request.EmailOrUsername)
                ?? await _userManager.FindByEmailAsync(request.EmailOrUsername);

            if (user == null)
                return new AuthResponse { Succeeded = false, Message = "Kullanıcı adı veya e-posta hatalıdır" };

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                return new AuthResponse { Succeeded = false, Message = "Hatalı şifre girdiniz" };

            Token token = _tokenHandler.CreateAccessToken(10);
            return new AuthResponse { Succeeded = true, Token = token };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (request.Password != request.ConfirmPassword)
                return new AuthResponse { Succeeded = false, Message = "Şifreler uyuşmuyor" };

            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                Email = request.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new AuthResponse { Succeeded = false, Message = "Kayıt işlemi başarısız oldu" };

            return new AuthResponse { Succeeded = true, Message = "Kayıt işlemi başarılı oldu, giriş yapabilirsiniz..." };
        }
    }
}
