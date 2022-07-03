using FluentValidation;
using OmegaFY.Blog.Application.Commands.Users.Login;

namespace OmegaFY.Blog.Application.Validations.Commands.Users;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();

        RuleFor(x => x.Password).NotEmpty();
    }
}