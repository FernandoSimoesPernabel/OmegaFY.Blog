using OmegaFY.Blog.Common.Configs;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class DatabaseRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        DatabaseOptions database = builder.Configuration.GetDatabaseConfig();

        if (database.In(DatabaseOptions.SqlLite, DatabaseOptions.SqlServer))
        {
            if (database == DatabaseOptions.SqlLite)
                builder.Services.AddSqlLiteEntityFrameworkContexts(builder.Configuration, builder.Environment);

            if (database == DatabaseOptions.SqlServer)
                builder.Services.AddSqlServerEntityFrameworkContexts(builder.Configuration, builder.Environment);

            builder.Services.AddEntityFrameworkRepositories();
            builder.Services.AddEntityFrameworkQueryProviders();

            return;
        }

        if (database == DatabaseOptions.MongoDB) { }

        if (database == DatabaseOptions.CosmoDB) { }

        if (database == DatabaseOptions.RavenDB) { }
    }
}
