
using EFCoreValueConverters.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace EFCoreValueConverters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<ExampleDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=ExampleDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
