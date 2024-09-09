using Microsoft.Extensions.DependencyInjection;
using PersonelBlogBackend.Application.Abstractions;
using PersonelBlogBackend.Infrastructure.Services;

namespace PersonelBlogBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
