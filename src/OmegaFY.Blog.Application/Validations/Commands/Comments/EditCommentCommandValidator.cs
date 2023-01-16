using FluentValidation;
using OmegaFY.Blog.Application.Commands.Comments.EditComment;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Application.Validations.Commands.Comments;

public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();

        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.NewContent).NotEmpty().Length(PostConstants.MIN_COMMENT_BODY_LENGTH, PostConstants.MAX_COMMENT_BODY_LENGTH);
    }
}