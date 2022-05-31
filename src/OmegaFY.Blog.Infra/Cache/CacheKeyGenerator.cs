namespace OmegaFY.Blog.Infra.Cache;

public static class CacheKeyGenerator
{
    public static string RefreshTokenKey(Guid refreshToken) => $"{CacheKeysConstants.REFRESH_TOKEN_PREFIX}_{refreshToken}";
}