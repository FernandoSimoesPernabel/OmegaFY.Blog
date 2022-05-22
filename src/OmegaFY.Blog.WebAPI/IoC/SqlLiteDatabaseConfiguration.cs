using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class SqlLiteDatabaseConfiguration : IDependencyInjectionRegister
{
    public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkContexts(configuration);
        services.AddEntityFrameworkRepositories();
        services.AddEntityFrameworkQueryProviders();

        return services;
    }
}
