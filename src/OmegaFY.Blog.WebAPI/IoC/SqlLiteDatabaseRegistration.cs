using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class SqlLiteDatabaseRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddEntityFrameworkContexts(builder.Configuration);
        builder.Services.AddEntityFrameworkRepositories();
        builder.Services.AddEntityFrameworkQueryProviders();
    }
}
