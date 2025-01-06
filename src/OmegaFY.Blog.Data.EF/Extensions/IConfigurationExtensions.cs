using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OmegaFY.Blog.Common.Configs;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class IConfigurationExtensions
{
    public static DatabaseOptions GetDatabaseConfig(this IConfiguration configuration) => configuration.GetValue<DatabaseOptions>("ConnectionStrings:Database");

    public static string GetSqliteConnectionString(this IConfiguration configuration) => configuration.GetConnectionString(nameof(DatabaseOptions.Sqlite));

    public static string GetSqlServerConnectionString(this IConfiguration configuration) => configuration.GetConnectionString(nameof(DatabaseOptions.SqlServer));
}