using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Comments.RemoveReaction;

public sealed record class RemoveReactionCommand : CommandMediatRBase<RemoveReactionCommandResult>
{
    public Guid PostId { get; set; }

    public Guid CommentId { get; set; }
}