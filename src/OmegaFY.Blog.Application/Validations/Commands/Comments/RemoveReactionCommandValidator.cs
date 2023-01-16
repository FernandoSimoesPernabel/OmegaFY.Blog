using FluentValidation;
using OmegaFY.Blog.Application.Commands.Comments.RemoveReaction;

namespace OmegaFY.Blog.Application.Validations.Commands.Comments;

public class RemoveReactionCommandValidator : AbstractValidator<RemoveReactionCommand>
{
    public RemoveReactionCommandValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();

        RuleFor(x => x.PostId).NotEmpty();
    }
}