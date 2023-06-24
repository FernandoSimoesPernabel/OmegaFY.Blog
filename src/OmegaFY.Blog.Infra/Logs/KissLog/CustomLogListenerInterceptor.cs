using KissLog;
using KissLog.Http;

namespace OmegaFY.Blog.Infra.Logs.KissLog;

public class CustomLogListenerInterceptor : ILogListenerInterceptor
{
    private readonly ILogListenerInterceptor[] _listenerInterceptors = new ILogListenerInterceptor[] { };

    public bool ShouldLog(HttpRequest httpRequest, ILogListener listener)
    {
        foreach (ILogListenerInterceptor service in _listenerInterceptors)
            if (!service.ShouldLog(httpRequest, listener)) return false;

        return true;
    }

    public bool ShouldLog(LogMessage message, ILogListener listener)
    {
        foreach (ILogListenerInterceptor service in _listenerInterceptors)
            if (!service.ShouldLog(message, listener)) return false;

        return true;
    }

    public bool ShouldLog(FlushLogArgs args, ILogListener listener)
    {
        foreach (ILogListenerInterceptor service in _listenerInterceptors)
            if (!service.ShouldLog(args, listener)) return false;

        return true;
    }
}