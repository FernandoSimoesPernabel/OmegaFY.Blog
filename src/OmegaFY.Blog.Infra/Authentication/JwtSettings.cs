namespace OmegaFY.Blog.Infra.Authentication;

internal class JwtSettings
{
    public string ValidAudience { get; set; }

    public string ValidIssuer { get; set; }

    public string Secret { get; set; }
}