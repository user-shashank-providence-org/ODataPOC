using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;

namespace ODataPOC.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        [EnableQuery]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        //public IEnumerable<WeatherForecast> Get(ODataQueryOptions<WeatherForecast> queryOptions)
        public IEnumerable<WeatherForecast> Get()
        {
            //IEnumerable values = queryOptions.ApplyTo(WeatherForecast.);
            return Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public bool Post([FromBody] WeatherForecast weatherForecast)
        {
            return true;
        }

        [HttpPatch("{id}")]
        public bool Patch(int id, [FromBody] Delta<WeatherForecast> weatherForecast)
        {
            return true;
        }
    }
}