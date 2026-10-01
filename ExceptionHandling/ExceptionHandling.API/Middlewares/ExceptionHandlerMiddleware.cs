using ExceptionHandling.API.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ExceptionHandling.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is ValidationException)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        message = ex.Message
                    });

                    return;
                }

                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        message = ex.Message
                    });

                    return;
                }

                if (ex is DependencyFailureException)
                {
                    context.Response.StatusCode = 502;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        message = ex.Message
                    });

                    return;
                }

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });

                return;
            }
        }
    }
}
