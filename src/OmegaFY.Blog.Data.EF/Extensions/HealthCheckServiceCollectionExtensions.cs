using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class HealthCheckServiceCollectionExtensions
{
    public static IHealthChecksBuilder AddSqliteHealthCheck(this IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
    {
        return healthChecksBuilder.AddSqlite(configuration.GetSqliteConnectionString(), name: "Sqlite", tags: ["database", "storage", "sql"]);
    }
}