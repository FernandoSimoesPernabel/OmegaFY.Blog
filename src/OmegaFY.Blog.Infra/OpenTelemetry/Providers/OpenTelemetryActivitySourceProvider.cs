using Microsoft.Extensions.Options;
using OmegaFY.Blog.Infra.OpenTelemetry.Configs;
using System.Diagnostics;

namespace OmegaFY.Blog.Infra.OpenTelemetry.Providers;

internal class OpenTelemetryActivitySourceProvider : IOpenTelemetryRegisterProvider
{
    private readonly ActivitySource _activitySource;

    public OpenTelemetryActivitySourceProvider(IOptions<OpenTelemetrySettings> openTelemetrySettings)
        => _activitySource = new ActivitySource(openTelemetrySettings.Value.ServiceName);

    public Activity StartActivity(string activityName) => _activitySource.StartActivity(activityName);
}