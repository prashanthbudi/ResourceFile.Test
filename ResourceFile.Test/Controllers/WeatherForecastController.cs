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
    public class ResourceTestController : ControllerBase
    {
      
        private readonly IStringLocalizer<Pattern> _stringLocalizer;

        public ResourceTestController(IStringLocalizer<Pattern> stringLocalizer)
        {
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
