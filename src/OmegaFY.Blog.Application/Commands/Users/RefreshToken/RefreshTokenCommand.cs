using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Users.RefreshToken;

public class RefreshTokenCommand : CommandMediatRBase<RefreshTokenCommandResult>
{
    public string CurrentToken { get; set; }

    public Guid RefreshToken { get; set; }
}