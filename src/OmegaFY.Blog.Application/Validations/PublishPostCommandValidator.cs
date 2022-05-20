using FluentValidation;
using OmegaFY.Blog.Application.Commands.PublishPost;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Application.Validations;

public class PublishPostCommandValidator : AbstractValidator<PublishPostCommand>
{
    public PublishPostCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(PostConstants.MIN_TITLE_SIZE, PostConstants.MAX_TITLE_SIZE);

        RuleFor(x => x.SubTitle).NotEmpty().Length(PostConstants.MIN_SUBTITLE_SIZE, PostConstants.MAX_SUBTITLE_SIZE);

        RuleFor(x => x.Body).NotEmpty().Length(PostConstants.MIN_BODY_SIZE, PostConstants.MAX_BODY_SIZE);
    }
}
