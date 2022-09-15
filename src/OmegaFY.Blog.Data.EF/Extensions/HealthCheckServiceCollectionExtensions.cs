using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class HealthCheckServiceCollectionExtensions
{
    public static IHealthChecksBuilder AddSqlLiteHealthCheck(this IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
    {
        return healthChecksBuilder.AddSqlite(configuration.GetSqlLiteConnectionString(), name: "SqlLite", tags: new string[] { "database", "storage", "sql" });
    }
}