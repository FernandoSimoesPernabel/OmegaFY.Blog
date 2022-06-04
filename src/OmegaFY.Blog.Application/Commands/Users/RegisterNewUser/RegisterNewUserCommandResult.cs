using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public class RegisterNewUserCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }

    public RegisterNewUserCommandResult() { }

    public RegisterNewUserCommandResult(Guid id, string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        Id = id;
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}