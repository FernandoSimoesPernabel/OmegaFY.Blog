using FluentValidation;
using OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

namespace OmegaFY.Blog.Application.Validations.Commands.Shares;

public class UnsharePostCommandValidator : AbstractValidator<UnsharePostCommand>
{
    public UnsharePostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.ShareId).NotEmpty();
    }
}