using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

public sealed record class ReactToCommentCommandResult : GenericResult, ICommandResult
{
    public Guid ReactionId { get; }

    public Guid CommentId { get; }

    public Guid PostId { get; }

    public CommentReaction Reaction { get; }

    public ReactToCommentCommandResult(Guid reactionId, Guid commentId, Guid postId, CommentReaction reaction)
    {
        ReactionId = reactionId;
        CommentId = commentId;
        PostId = postId;
        Reaction = reaction;
    }
}