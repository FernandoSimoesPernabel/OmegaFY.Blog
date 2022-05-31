using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.Login;

public class LoginCommandResult : GenericResult, ICommandResult
{
    public string Token { get; }

    public Guid RefreshToken { get; }

    public LoginCommandResult() { }

    public LoginCommandResult(string token, Guid refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}