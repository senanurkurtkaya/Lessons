namespace ExceptionHandling.API.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Username", out var username))
            {
                await BlockAccessAsync(context);

                return;
            }

            if (!context.Request.Headers.TryGetValue("Password", out var password))
            {
                await BlockAccessAsync(context);

                return;
            }

            if (username != "admin" || password != "password")
            {
                await BlockAccessAsync(context);

                return;
            }

            await _next(context);
        }

        private async Task BlockAccessAsync(HttpContext context)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Unauthorized"
            });
        }
    }
}
