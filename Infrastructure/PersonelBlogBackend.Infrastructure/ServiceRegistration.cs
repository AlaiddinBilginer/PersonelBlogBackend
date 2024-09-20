using Microsoft.Extensions.DependencyInjection;
using PersonelBlogBackend.Application.Abstractions;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Infrastructure.Services;
using PersonelBlogBackend.Infrastructure.Services.Auth;

namespace PersonelBlogBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
