using PersonelBlogBackend.WebAPI.Middlewares;

namespace PersonelBlogBackend.WebAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseUsernameLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UsernameLoggingMiddleware>();
        }
    }
}
