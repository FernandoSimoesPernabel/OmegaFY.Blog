using FluentValidation;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;

namespace OmegaFY.Blog.Application.Validations.Commands.Posts;

public class MakePostPublicCommandValidator : AbstractValidator<MakePostPublicCommand>
{
    public MakePostPublicCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}