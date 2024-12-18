﻿using Microsoft.Extensions.Caching.Distributed;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Common.Helpers;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Cache.Keys;

namespace OmegaFY.Blog.Infra.Extensions;

public static class IDistributedCacheExtensions
{
    public static async Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken cancellationToken)
    {
        string valueFromCache = await distributedCache.GetStringAsync(key, cancellationToken);
        return valueFromCache is null ? default : JsonSerializerHelper.Deserialize<T>(valueFromCache);
    }

    public static Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken cancellationToken)
    {
        string valueAsJsonString = value.ToJson();
        return distributedCache.SetStringAsync(key, valueAsJsonString, options, cancellationToken);
    }

    public static Task SetAuthenticationTokenCacheAsync(
        this IDistributedCache distributedCache,
        Guid userId,
        AuthenticationToken authToken,
        CancellationToken cancellationToken)
    {
        return distributedCache.SetAsync(
           CacheKeyGenerator.RefreshTokenKey(userId, authToken.RefreshToken),
           authToken,
           new DistributedCacheEntryOptions() { AbsoluteExpiration = authToken.RefreshTokenExpirationDate },
           cancellationToken);
    }

    public static Task RemoveAuthenticationTokenCacheAsync(this IDistributedCache distributedCache, Guid userId, Guid refreshToken, CancellationToken cancellationToken)
        => distributedCache.RemoveAsync(CacheKeyGenerator.RefreshTokenKey(userId, refreshToken), cancellationToken);
}