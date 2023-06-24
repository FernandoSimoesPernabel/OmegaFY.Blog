using KissLog.CloudListeners.RequestLogsListener;

namespace OmegaFY.Blog.Infra.Logs.KissLog;

public class CustomObfuscationService : IObfuscationService
{
    private readonly IObfuscationService[] _services = new IObfuscationService[] { };

    public bool ShouldObfuscate(string key, string value, string propertyName)
    {
        foreach (IObfuscationService service in _services)
            if (service.ShouldObfuscate(key, value, propertyName)) return true;

        return false;
    }
}