namespace OmegaFY.Blog.Infra.Authentication.Configs;

public readonly struct AuthenticationToken
{
    public string Token { get; }

    public Guid RefreshToken { get; }

    public AuthenticationToken(string token)
    {
        Token = token;
        RefreshToken = Guid.NewGuid();
    }
}