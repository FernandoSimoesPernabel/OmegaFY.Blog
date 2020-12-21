using Microsoft.Extensions.Configuration;
using OmegaFY.Blog.WebAPI.Configuration.Options;

namespace OmegaFY.Blog.WebAPI.Extensions
{

    public static class IConfigurationExtensions
    {

        public static DatabaseConfigurationOptions ReadDatabaseOptionsFromAppSettings(this IConfiguration configuration)
        {
            DatabaseConfigurationOptions databaseOptions = new DatabaseConfigurationOptions();
            configuration.GetSection("DatabaseConfigurationOptions").Bind(databaseOptions);
            return databaseOptions;
        }

    }

}
