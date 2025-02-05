using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Constants;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class HealthCheckServiceCollectionExtensions
{
    public static IHealthChecksBuilder AddMongoDbHealthCheck(this IHealthChecksBuilder healthChecksBuilder)
    {
        return healthChecksBuilder.AddMongoDb(
            serviceProvider => serviceProvider.GetRequiredService<IMongoClient>(), 
            factory => MongoDbContants.DATABASE_NAME, 
            name: "mongodb", 
            failureStatus: HealthStatus.Unhealthy, 
            tags: ["db", "mongodb"], 
            timeout: TimeSpan.FromSeconds(5));
    }
}