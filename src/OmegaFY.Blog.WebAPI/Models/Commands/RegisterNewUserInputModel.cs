using OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class RegisterNewUserInputModel
{
    public string Email { get; set; }

    public string DisplayName { get; set; }

    public string Password { get; set; }

    public RegisterNewUserCommand ToCommand() => new RegisterNewUserCommand(Email, DisplayName, Password);
}