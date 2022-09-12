using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class NotificationProvidersRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder) => builder.Services.AddNotificationProviders(builder.Configuration);
}