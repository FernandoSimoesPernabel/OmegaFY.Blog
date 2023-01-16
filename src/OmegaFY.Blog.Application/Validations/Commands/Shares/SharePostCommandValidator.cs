using FluentValidation;
using OmegaFY.Blog.Application.Commands.Shares.SharePost;

namespace OmegaFY.Blog.Application.Validations.Commands.Shares;

public class SharePostCommandValidator : AbstractValidator<SharePostCommand>
{
    public SharePostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}