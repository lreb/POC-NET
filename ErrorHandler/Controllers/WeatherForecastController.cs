using AutoWrapper.Wrappers;
using ErrorHandler.ResponseWrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandler.Controllers
{
    [ApiController]
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
        public async Task<ApiServiceResponse> Get()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return new ApiServiceResponse(DateTime.UtcNow, InternalSuccessStatuses.S002.ToString(), data,
            new Pagination
            {
                CurrentPage = 1,
                PageSize = 10,
                TotalRecords = 200,
                TotalPages = 20
            });
        }


        [HttpGet, Route("Error2")]
        public async Task<ApiServiceResponse> GetError2()
        {

            throw new ApiException(
              new Error("An error ...", InternalErrorStatuses.E001.ToString(),
                new InnerError("12132-5434", DateTime.Now.ToShortDateString())
            ));

            return null;
        }
    }
}
