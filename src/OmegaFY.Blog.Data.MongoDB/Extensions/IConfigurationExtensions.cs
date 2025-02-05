using Microsoft.Extensions.Configuration;
using OmegaFY.Blog.Common.Configs;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class IConfigurationExtensions
{
    public static string GetMongoDbConnectionString(this IConfiguration configuration) => configuration.GetConnectionString(nameof(DatabaseOptions.MongoDb));
}
