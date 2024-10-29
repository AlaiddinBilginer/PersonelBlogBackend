using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PersonelBlogBackend.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .SelectMany(x => x.Value.Errors.Select(e => new
                    {
                        Field = x.Key,
                        Message = e.ErrorMessage
                    }))
                    .ToList();

                context.Result = new BadRequestObjectResult(errors);
                return;
            }

            await next();
        }
    }
}
