using Microsoft.Extensions.Caching.Distributed;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Cache.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Extensions;

public static class IDistributedCacheExtensions
{
    public static async Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken cancellationToken)
    {
        string valueFromCache = await distributedCache.GetStringAsync(key, cancellationToken);
        return valueFromCache is null ? default : JsonSerializer.Deserialize<T>(valueFromCache);
    }

    public static async Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken cancellationToken)
    {
        string valueAsJsonString = JsonSerializer.Serialize(value);
        await distributedCache.SetStringAsync(key, valueAsJsonString, options, cancellationToken);
    }

    public static async Task SetAuthenticationTokenCacheAsync(
        this IDistributedCache distributedCache, 
        Guid userId, 
        AuthenticationToken authToken, 
        CancellationToken cancellationToken)
    {
        await distributedCache.SetAsync(
            CacheKeyGenerator.RefreshTokenKey(userId, authToken.RefreshToken),
            authToken,
            new DistributedCacheEntryOptions() { AbsoluteExpiration = authToken.RefreshTokenExpirationDate },
            cancellationToken);
    }
}