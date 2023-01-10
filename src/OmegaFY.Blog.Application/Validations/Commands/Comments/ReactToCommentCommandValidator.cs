using FluentValidation;
using OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

namespace OmegaFY.Blog.Application.Validations.Commands.Comments;

public class ReactToCommentCommandValidator : AbstractValidator<ReactToCommentCommand>
{
    public ReactToCommentCommandValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();

        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.Reaction).IsInEnum();
    }
}