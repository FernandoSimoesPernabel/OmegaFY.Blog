using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

public sealed record class ReactToCommentCommand : CommandMediatRBase<ReactToCommentCommandResult>
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public CommentReaction Reaction { get; set; }
}