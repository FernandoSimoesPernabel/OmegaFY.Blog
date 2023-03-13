using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.RefreshToken;

public class RefreshTokenCommandResult : GenericResult, ICommandResult
{
    public string Token { get; }

    public DateTime TokenExpirationDate { get; }

    public Guid RefreshToken { get; }

    public DateTime RefreshTokenExpirationDate { get; }

    public RefreshTokenCommandResult(string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}