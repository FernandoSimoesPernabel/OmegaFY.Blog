using OmegaFY.Blog.Application.Commands.Users.Login;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class LoginInputModel
{
    public string Email { get; set; }

    public string Password { get; set; }

    public LoginCommand ToCommand()
    {
        return new LoginCommand(Email, Password);
    }
}