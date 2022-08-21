using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class IdentityUserRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityUserConfiguration(builder.Configuration);
        builder.Services.AddIdentity(builder.Configuration).AddEntityFrameworkIdentityUserConfiguration();
    }
}