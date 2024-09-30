using Serilog.Context;

namespace PersonelBlogBackend.WebAPI.Middlewares
{
    public class UsernameLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public UsernameLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var username = context.User?.Identity?.IsAuthenticated == true ? context.User.Identity.Name : null;
            LogContext.PushProperty("user_name", username);
            
            await _next(context);
        }
    }
}
