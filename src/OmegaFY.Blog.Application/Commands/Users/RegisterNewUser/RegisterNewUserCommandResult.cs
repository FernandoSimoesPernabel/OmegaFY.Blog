using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public sealed record class RegisterNewUserCommandResult : GenericResult, ICommandResult
{
    public Guid UserId { get; }

    public string Token { get; }

    public DateTime TokenExpirationDate { get; }

    public Guid RefreshToken { get; }

    public DateTime RefreshTokenExpirationDate { get; }

    public RegisterNewUserCommandResult(Guid userId, string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        UserId = userId;
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}