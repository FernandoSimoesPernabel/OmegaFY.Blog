using FluentValidation;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;

namespace OmegaFY.Blog.Application.Validations.Commands.Posts;

public class MakePostPrivateCommandValidator : AbstractValidator<MakePostPrivateCommand>
{
    public MakePostPrivateCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}