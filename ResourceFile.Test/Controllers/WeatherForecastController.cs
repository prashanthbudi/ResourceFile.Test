using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ResourceConfig;
using System.Linq;
using System.Text.RegularExpressions;

namespace ResourceFile.Test.Controllers
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
        private readonly IStringLocalizer<Pattern> _stringLocalizer;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<Pattern> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public string[] Get()
        {
            
            var reg = _stringLocalizer["Pattern"].Value;
            string s = "there are some very bad filthy of absurd things dirtydly";

            var match = Regex.Matches(s, reg.ToString())
                        .OfType<Match>()
                        .Select(m => m.Value)
                        .ToArray();

            return match;
        }
    }
}
