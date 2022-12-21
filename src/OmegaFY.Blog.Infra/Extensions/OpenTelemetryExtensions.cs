using OmegaFY.Blog.Infra.OpenTelemetry.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Extensions;

public static class OpenTelemetryExtensions
{
    public static bool ShouldMonitorRoute(this string route) => route?.Contains(OpenTelemetryConstants.API_ROUTE) ?? false;
}