using OmegaFY.Blog.Infra.OpenTelemetry.Constants;

namespace OmegaFY.Blog.Infra.Extensions;

public static class OpenTelemetryExtensions
{
    public static bool ShouldMonitorRoute(this string route) => route?.Contains(OpenTelemetryConstants.API_ROUTE) ?? false;
}