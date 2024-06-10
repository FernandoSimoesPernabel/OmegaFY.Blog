using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.Login;

public sealed record class LoginCommandResult : GenericResult, ICommandResult
{
    public Guid UserId { get; }

    public string DisplayName { get; }

    public string Email { get; }

    public string Token { get; }

    public DateTime TokenExpirationDate { get; }

    public Guid RefreshToken { get; }

    public DateTime RefreshTokenExpirationDate { get; }

    public LoginCommandResult() { }

    public LoginCommandResult(Guid userId, string displayName, string email, string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        UserId = userId;
        DisplayName = displayName;
        Email = email;
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}