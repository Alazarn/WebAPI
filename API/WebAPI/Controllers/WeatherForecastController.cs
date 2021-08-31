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
        private readonly IRepositoryWrapper repository;

        public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            

            return new string[] { "value1", "value2" };
        }

        //    [HttpGet]
        //public IEnumerable<string> GetLog()
        //{
        //    logger.LogInfo("Here is info message from our values controller.");
        //    logger.LogDebug("Here is debug message from our values controller.");
        //    logger.LogWarn("Here is warn message from our values controller.");
        //    logger.LogError("Here is an error message from our values controller.");
        //    return new string[] { "value1", "value2" };
        //}        
    }
}
