using Application.Abstractions.Caching;
using Asp.Versioning;
using eCommerceManager.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceManager.API.Controllers
{
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ICacheService cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheService cache)
        {
            _logger = logger;
            this.cache = cache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [AllowAnonymous]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var test = await cache.GetAsync<IEnumerable<WeatherForecast>>("Summary", default);
            if (test != null)
            {
                return test;
            }
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            await cache.SetAsync("Summary", result);
            return result;
        }
    }
}