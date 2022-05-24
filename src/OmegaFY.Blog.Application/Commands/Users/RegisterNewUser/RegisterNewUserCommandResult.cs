using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public class RegisterNewUserCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public RegisterNewUserCommandResult() { }

    public RegisterNewUserCommandResult(Guid id)
    {
        Id = id;
    }
}