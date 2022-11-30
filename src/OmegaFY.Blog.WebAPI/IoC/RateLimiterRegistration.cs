using OmegaFY.Blog.Infra.IoC;
using OmegaFY.Blog.Infra.Extensions;

namespace OmegaFY.Blog.WebAPI.IoC;

public class RateLimiterRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddWebApiRateLimiter(builder.Configuration);
    }
}