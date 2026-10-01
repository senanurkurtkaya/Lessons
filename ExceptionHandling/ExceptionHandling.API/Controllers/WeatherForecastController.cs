using ExceptionHandling.API.Exceptions;
using ExceptionHandling.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExceptionHandling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("HataFirlat")]
        public async Task<IActionResult> Throw()
        {
            throw new DependencyFailureException("Dış kaynaklı hata oluştu.");

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new ValidationException("FirstName boş olamaz.");
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                throw new ValidationException("LastName boş olamaz.");
            }

            return Ok();
        }
    }
}
