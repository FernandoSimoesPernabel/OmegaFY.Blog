namespace OmegaFY.Blog.Infra.Authentication.Configs;

public readonly struct AuthenticationToken
{
    public string Token { get; }

    public string RefreshToken { get; }

    public AuthenticationToken(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}