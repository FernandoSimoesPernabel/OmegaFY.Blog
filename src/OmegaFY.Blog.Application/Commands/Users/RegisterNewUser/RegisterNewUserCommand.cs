using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public sealed record class RegisterNewUserCommand : CommandMediatRBase<RegisterNewUserCommandResult>
{
    public string Email { get; set; }

    public string DisplayName { get; set; }

    public string Password { internal get; set; }
}