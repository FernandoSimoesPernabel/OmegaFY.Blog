using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.Login;

public class LoginCommandResult : GenericResult, ICommandResult
{
    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }

    public LoginCommandResult() { }

    public LoginCommandResult(string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}