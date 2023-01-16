using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public class RegisterNewUserCommand : CommandMediatRBase<RegisterNewUserCommandResult>
{
    public string Email { get; set; }

    public string DisplayName { get; set; }

    public string Password { internal get; set; }

    public RegisterNewUserCommand() { }

    public RegisterNewUserCommand(string email, string displayName, string password)
    {
        Email = email;
        DisplayName = displayName;
        Password = password;
    }
}