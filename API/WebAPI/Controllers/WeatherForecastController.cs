using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager logger;        

        public WeatherForecastController(ILoggerManager logger)
        {
            this.logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInfo("Here is info message from our values controller.");
            logger.LogDebug("Here is debug message from our values controller.");
            logger.LogWarn("Here is warn message from our values controller.");
            logger.LogError("Here is an error message from our values controller.");
            return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
