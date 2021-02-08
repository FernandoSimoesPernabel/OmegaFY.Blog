using Microsoft.Extensions.Caching.Distributed;
using OmegaFY.Blog.Domain.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Services
{

    internal class CacheServicesDistributedCache : ICacheServices
    {

        private readonly IDistributedCache _distributedCache;

        private readonly DistributedCacheEntryOptions _cacheOptions;

        public CacheServicesDistributedCache(IDistributedCache distributedCache, DistributedCacheEntryOptions cacheOptions)
        {
            _distributedCache = distributedCache;
            _cacheOptions = cacheOptions;
        }

        public async Task<string> GetStringAsync(string key, CancellationToken token)
            => await _distributedCache.GetStringAsync(key, token);

        public async Task SetStringAsync(string key, string value, CancellationToken token)
            => await _distributedCache.SetStringAsync(key, value, _cacheOptions, token);

    }

}
