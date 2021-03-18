

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace clean_sharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController, LandingRepository
    {
        private readonly Lazy<LandingUseCase> fetcher = new Lazy<LandingUseCase>(() => LandingGatewayInjector.Instancia.fetch);

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public Landing doFetch()
        {
            return processUseCase<Void ,Landing>(null, fetcher.Value).value;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            var process = doFetch();
            return process.results.AsEnumerable();
        }
    }
}

