using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonelBlogBackend.Application.Abstractions.Services.User;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities.Identity;
using PersonelBlogBackend.Persistence.Contexts;
using PersonelBlogBackend.Persistence.Repositories;
using PersonelBlogBackend.Persistence.Services;

namespace PersonelBlogBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonelBlogDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<PersonelBlogDbContext>();

            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPostImageReadRepository, PostImageReadRepository>();
            services.AddScoped<IPostImageWriteRepository, PostImageWriteRepository>();
        }
    }
}
