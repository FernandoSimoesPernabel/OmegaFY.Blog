using System.Diagnostics;

namespace OmegaFY.Blog.Infra.OpenTelemetry;

public interface IOpenTelemetryRegisterProvider
{
    public Activity StartActivity(string activityName);
}