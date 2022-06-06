namespace OmegaFY.Blog.Infra.Cache.Keys;

public static class CacheKeyGenerator
{
    public static string RefreshTokenKey(Guid userId, Guid refreshToken) => $"{CacheKeysConstants.REFRESH_TOKEN_PREFIX}_{userId}_{refreshToken}";
}