using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class IdentityUserConfiguration : IDependencyInjectionRegister
{
    public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityUserConfiguration(configuration);
        services.AddEntityFrameworkIdentityUserConfiguration();

        return services;
    }
}