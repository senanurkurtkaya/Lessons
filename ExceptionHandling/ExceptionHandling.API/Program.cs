
using ExceptionHandling.API.Middlewares;
using Scalar.AspNetCore;

namespace ExceptionHandling.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Burada throw edilirse uygulama hiç devam etmeyip, API da ayağa kalkmaz ve uygulama kapanır.
            // throw new Exception("Hata oluştu.");

            // Add services to the container.
            builder.Services.AddControllers(config =>
            {
                config.ModelValidatorProviders.Clear();
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); 
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<ExampleMiddleware>();

            app.Run();

            // Burada throw edildiğinde host kapanana kadar buraya hiç gelmez, host kapanırken buraya gelir ve throw eder, bu da uygulamayı durdurur.
            throw new Exception("Hata oluştu.");
        }
    }
}
