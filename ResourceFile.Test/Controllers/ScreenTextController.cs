using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ResourceConfig;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ResourceFile.Application;

namespace ResourceFile.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreenTextController : ControllerBase
    {
        IStringLocalizer<Profanity> _stringLocalizer;
        public ScreenTextController(IStringLocalizer<Profanity> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public Dictionary<string, string> Get()
        {

            ProfanityChecker matcher = new ProfanityChecker(_stringLocalizer);

            var values = matcher.GetProfanityMatches();

            return values;
        }
    }
}
