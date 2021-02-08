using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Infra.Services;
using System;

namespace OmegaFY.Blog.Infra.Extensions
{
    public static class DistributedCacheCollectionExtensions
    {

        public static IServiceCollection AddDistributedMemoryCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(GetMinutesToCacheExpirationFromAppSettings(configuration))
            });

            services.AddScoped<ICacheServices, CacheServicesDistributedCache>();

            return services.AddDistributedMemoryCache();
        }

        private static int GetMinutesToCacheExpirationFromAppSettings(IConfiguration configuration)
        {
            int.TryParse(configuration.GetSection("MinutesToCacheExpiration")?.Value, out int minutesToCacheExpiration);
            return minutesToCacheExpiration;
        }

    }
}
