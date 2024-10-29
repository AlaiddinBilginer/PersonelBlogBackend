using FluentValidation.AspNetCore;
using PersonelBlogBackend.Application.Validators.Comments;
using PersonelBlogBackend.Infrastructure.Filters;

namespace PersonelBlogBackend.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            })
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            services.AddFluentValidationServices();

        }

        private static void AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddFluentValidation(configuration =>
                configuration.RegisterValidatorsFromAssemblyContaining<AddCommentCommandRequestValidator>());
        }

    }
}
