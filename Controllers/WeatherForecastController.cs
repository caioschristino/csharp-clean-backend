

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace clean_sharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
<<<<<<< HEAD
        private readonly Lazy<LandingUseCase> fetcher = new Lazy<LandingUseCase>(() => LandingGatewayInjector.Instancia.fetch);

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public Landing doFetch()
        {
            return processUseCase<Void ,Landing>(null, fetcher.Value).value;
=======
        private readonly Lazy<LandingUseCase> fetcher = new Lazy<LandingUseCase>(() => LandingGatewayInjector.Self.fetch);
        
        public Landing doFetch()
        {
            return processUseCase<Void, Landing>(null, LandingGatewayInjector.Self.fetch).value;
>>>>>>> main
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            var process = doFetch();
            return process.results.AsEnumerable();
        }
    }
}

