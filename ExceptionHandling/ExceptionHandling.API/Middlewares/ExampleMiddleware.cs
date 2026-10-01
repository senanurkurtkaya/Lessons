namespace ExceptionHandling.API.Middlewares
{
    public class ExampleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("BasketId", out var basketId))
            {
                Console.WriteLine($"BasketId: {basketId}");
            }

            await _next(context);

            Console.WriteLine("Response");
        }
    }
}
