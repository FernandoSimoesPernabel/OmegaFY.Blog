using FluentValidation;
using OmegaFY.Blog.Application.Commands.Comments.RemoveComment;

namespace OmegaFY.Blog.Application.Validations.Commands.Comments;

public class RemoveCommentCommandValidator : AbstractValidator<RemoveCommentCommand>
{
    public RemoveCommentCommandValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();

        RuleFor(x => x.PostId).NotEmpty();
    }
}