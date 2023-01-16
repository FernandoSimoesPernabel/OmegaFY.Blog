using FluentValidation;
using OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Application.Validations.Commands.Posts;

public class ChangePostContentCommandValidator : AbstractValidator<ChangePostContentCommand>
{
    public ChangePostContentCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.Title).NotEmpty().Length(PostConstants.MIN_TITLE_LENGTH, PostConstants.MAX_TITLE_LENGTH);

        RuleFor(x => x.SubTitle).NotEmpty().Length(PostConstants.MIN_SUBTITLE_LENGTH, PostConstants.MAX_SUBTITLE_LENGTH);

        RuleFor(x => x.Body).NotEmpty().Length(PostConstants.MIN_POST_BODY_LENGTH, PostConstants.MAX_POST_BODY_LENGTH);
    }
}