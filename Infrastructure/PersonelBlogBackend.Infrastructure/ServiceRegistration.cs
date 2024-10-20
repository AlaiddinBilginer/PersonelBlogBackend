using Microsoft.Extensions.DependencyInjection;
using PersonelBlogBackend.Application.Abstractions;
using PersonelBlogBackend.Application.Abstractions.Services.Auth;
using PersonelBlogBackend.Application.Abstractions.Storage;
using PersonelBlogBackend.Infrastructure.Services;
using PersonelBlogBackend.Infrastructure.Services.Auth;
using PersonelBlogBackend.Infrastructure.Services.Storage;

namespace PersonelBlogBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
