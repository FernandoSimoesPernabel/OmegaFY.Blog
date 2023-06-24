using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class LoggingRegistration //: IDependencyInjectionRegister //TODO
{
    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddKissLog();
    }
}