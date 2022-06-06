using FluentValidation;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Application.Validations.Commands.Posts;

public class PublishPostValidator : AbstractValidator<PublishPostCommand>
{
    public PublishPostValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(PostConstants.MIN_TITLE_SIZE, PostConstants.MAX_TITLE_SIZE);

        RuleFor(x => x.SubTitle).NotEmpty().Length(PostConstants.MIN_SUBTITLE_SIZE, PostConstants.MAX_SUBTITLE_SIZE);

        RuleFor(x => x.Body).NotEmpty().Length(PostConstants.MIN_BODY_SIZE, PostConstants.MAX_BODY_SIZE);
    }
}