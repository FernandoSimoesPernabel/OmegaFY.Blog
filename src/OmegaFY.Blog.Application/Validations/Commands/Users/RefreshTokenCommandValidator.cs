using FluentValidation;
using OmegaFY.Blog.Application.Commands.Users.RefreshToken;

namespace OmegaFY.Blog.Application.Validations.Commands.Users;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();

        RuleFor(x => x.CurrentToken).NotEmpty();

        RuleFor(x => x.UserId).NotEmpty();
    }
}