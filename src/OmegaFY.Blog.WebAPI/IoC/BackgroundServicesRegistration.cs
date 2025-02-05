using OmegaFY.Blog.Infra.IoC;
using OmegaFY.Blog.WebAPI.BackgroundServices;

namespace OmegaFY.Blog.WebAPI.IoC;

public class BackgroundServicesRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<ThreadsPerformanceMonitoringService>();
        builder.Services.AddHostedService<GarbageCollectorPerformanceMonitoringService>();
    }
}