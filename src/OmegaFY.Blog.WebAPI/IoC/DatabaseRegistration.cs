using OmegaFY.Blog.Common.Configs;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class DatabaseRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        DatabaseOptions database = builder.Configuration.GetDatabaseConfig();

        if (database.In(DatabaseOptions.Sqlite, DatabaseOptions.SqlServer))
        {
            if (database == DatabaseOptions.Sqlite)
                builder.Services.AddSqliteEntityFrameworkContexts(builder.Configuration, builder.Environment);

            if (database == DatabaseOptions.SqlServer)
                builder.Services.AddSqlServerEntityFrameworkContexts(builder.Configuration, builder.Environment);

            builder.Services.AddEntityFrameworkRepositories();
            builder.Services.AddEntityFrameworkQueryProviders();

            return;
        }

        if (database == DatabaseOptions.MongoDb)
        {
            builder.Services.AddMongoDb(builder.Configuration);
            builder.Services.AddMongoDbRepositories();

            return;
        }

        if (database == DatabaseOptions.CosmoDb) { }

        if (database == DatabaseOptions.RavenDb) { }
    }
}