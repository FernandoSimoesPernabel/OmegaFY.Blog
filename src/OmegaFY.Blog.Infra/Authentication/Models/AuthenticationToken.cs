namespace OmegaFY.Blog.Infra.Authentication.Models;

public readonly struct AuthenticationToken
{
    public string Token { get; }

    public DateTime TokenExpirationDate { get; }

    public Guid RefreshToken { get; }

    public DateTime RefreshTokenExpirationDate { get; }

    public AuthenticationToken(string token, DateTime tokenExpirationDate, DateTime refreshTokenExpirationDate)
    {
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = Guid.NewGuid();
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}