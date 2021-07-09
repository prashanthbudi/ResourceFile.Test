using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFile.Test
{
    internal static class LocalizationConfiguration
    {
        private const string ResourcesPath = "Resources";
        private const string DefaultCulture = "en-GB";

        internal static IServiceCollection ConfigureLocalizationSettings(this IServiceCollection services) =>
            services
                .AddLocalization(options =>
                    options.ResourcesPath = ResourcesPath);

        internal static IApplicationBuilder UseRequestLocalizationMiddleware(this IApplicationBuilder builder) =>
            builder
                .UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture(DefaultCulture),
                    SupportedCultures = new List<CultureInfo>
                    {
                    new CultureInfo(DefaultCulture),
                     new CultureInfo("en-US")
                    },
                    SupportedUICultures = new List<CultureInfo>
                    {
                    new CultureInfo(DefaultCulture),
                     new CultureInfo("en-US")
                    }
                });
    }
}
