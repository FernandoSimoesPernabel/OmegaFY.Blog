namespace OmegaFY.Blog.Infra.Authentication.Configs;

internal class JwtSettings
{
    public string Audience { get; set; }

    public string Issuer { get; set; }

    public string ValidAudience { get; set; }

    public string ValidIssuer { get; set; }

    public string Secret { get; set; }

    public TimeSpan TimeToExpireToken { get; set; }

    public TimeSpan TimeToExpireRefreshToken { get; set; }
}