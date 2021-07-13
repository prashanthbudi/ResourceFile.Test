using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ResourceConfig;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ResourceFile.Application
{
    public class ProfanityChecker
    {
        private readonly IStringLocalizer<Profanity> _stringLocalizer;

        public ProfanityChecker(IStringLocalizer<Profanity> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public Dictionary<string,string> GetProfanityMatches()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            var strList = _stringLocalizer.GetAllStrings();

            //// var reg = _stringLocalizer["Pattern"].Value;
            string s = "there are some very sid1rtyfi bad filthy of absurd things dirtydly anally damn piss";


            foreach (var pattern in strList)
            {
                var match = Regex.Matches(s, pattern.ToString(), RegexOptions.IgnoreCase)
                        .OfType<Match>()
                        .Select(m => m.Value)
                        .ToArray();

                values.Add(pattern, string.Join(",", match));
            }

            return values;
        }
    }
}
