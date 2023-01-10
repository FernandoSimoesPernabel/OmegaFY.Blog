using FluentValidation;
using OmegaFY.Blog.Application.Commands.Comments.MakeComment;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Application.Validations.Commands.Comments;

public class MakeCommentCommandValidator : AbstractValidator<MakeCommentCommand>
{
    public MakeCommentCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.Content).NotEmpty().Length(PostConstants.MIN_COMMENT_BODY_LENGTH, PostConstants.MAX_COMMENT_BODY_LENGTH);
    }
}