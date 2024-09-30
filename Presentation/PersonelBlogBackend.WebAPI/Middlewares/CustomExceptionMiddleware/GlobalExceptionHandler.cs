using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace PersonelBlogBackend.WebAPI.Middlewares.CustomExceptionMiddleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            _logger.LogError($"Hata alındı: {exception}");

            var message = exception switch
            {
                _ => "Internal Server Error"
            };

            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());

            return true;
        }
    }
}
