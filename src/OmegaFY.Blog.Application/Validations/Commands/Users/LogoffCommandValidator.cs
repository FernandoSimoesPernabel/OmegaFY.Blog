using FluentValidation;
using OmegaFY.Blog.Application.Commands.Users.Logoff;

namespace OmegaFY.Blog.Application.Validations.Commands.Users;

public class LogoffCommandValidator : AbstractValidator<LogoffCommand>
{
    public LogoffCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}