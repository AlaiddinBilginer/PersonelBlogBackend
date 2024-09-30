using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Abstractions;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Application.Abstractions.Services.User;
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
        private readonly IUserService _userService;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
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

            Token token = _tokenHandler.CreateAccessToken(accessTokenLifetime, user);
            await _userService.RenewRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);

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

        public async Task<AuthResponse> RefreshAccessTokenAsync(string refreshToken)
        {
            ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15, user);
                await _userService.RenewRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 30);
                return new AuthResponse { Succeeded = true, Token = token };
            }
            else
            {
                return new AuthResponse { Succeeded = false, Message = "Token geçerli değildir" };
            }
        }
    }
}
