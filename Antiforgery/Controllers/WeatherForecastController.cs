using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Antiforgery.Controllers
{
    [ApiController]
    // [AutoValidateAntiforgeryToken] //only validate the action method of type 'POST', it will automatically skip validation for methods like 'GET', 'OPTIONS', 'TRACE', etc.
    //[ValidateAntiForgeryToken] //will validate every request
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Save(PostObject value)
        {
            return Ok(new { message = $"Executed Post Save action method: {value.Number}" });
        }

        [HttpPut]
        public IActionResult Update(PostObject value)
        {
            return Ok(new { message = $"Executed PUT action method: {value.Number}" });
        }


        [HttpDelete]
        public IActionResult Delete(PostObject value)
        {
            return Ok(new { message = $"Executed DELETE action method: {value.Number}" });
        }
    }

    public class PostObject 
    {
        public int Number { get; set; }
    }
}
