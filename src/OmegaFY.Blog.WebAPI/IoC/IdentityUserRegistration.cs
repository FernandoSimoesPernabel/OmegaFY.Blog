using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Common.Configs;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class IdentityUserRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        DatabaseOptions database = builder.Configuration.GetDatabaseConfig();

        builder.Services.AddIdentityUserConfiguration(builder.Configuration);

        if (database.In(DatabaseOptions.Sqlite, DatabaseOptions.SqlServer))
        {
            builder.Services.AddEntityFrameworkUserManager();
            builder.Services.AddIdentity(builder.Configuration).AddEntityFrameworkIdentityUserConfiguration().AddDefaultTokenProviders();
        }

        if (database == DatabaseOptions.MongoDb)
        {
            builder.Services.AddMongoDbUserManager();
            builder.Services.AddIdentity(builder.Configuration).AddMongoDbIdentityUserConfiguration(builder.Configuration).AddDefaultTokenProviders();
        }
    }
}