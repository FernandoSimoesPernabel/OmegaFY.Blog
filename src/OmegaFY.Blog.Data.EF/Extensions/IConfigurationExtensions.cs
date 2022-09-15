using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class IConfigurationExtensions
{
    public static string GetSqlLiteConnectionString(this IConfiguration configuration) => configuration.GetConnectionString("SqlLite");
}