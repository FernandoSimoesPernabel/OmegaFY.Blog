using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class OpenTelemetryRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder) => builder.Services.AddOpenTelemetry(builder.Configuration, builder.Environment);
}