using OmegaFY.Blog.Application.Commands.Users.Logoff;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class LogoffInputModel
{
    public Guid RefreshToken { get; set; }

    public LogoffCommand ToCommand()
    {
        return new LogoffCommand(RefreshToken);
    }
}