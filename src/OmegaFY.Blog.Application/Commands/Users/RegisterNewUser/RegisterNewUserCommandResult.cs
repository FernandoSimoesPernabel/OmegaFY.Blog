using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public class RegisterNewUserCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public string Token { get; set; }

    public string RefreshToken { get; set; }

    public RegisterNewUserCommandResult() { }

    public RegisterNewUserCommandResult(Guid id, string token, string refreshToken)
    {
        Id = id;
        Token = token;
        RefreshToken = refreshToken;
    }
}