using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

public class ReactToCommentCommandResult : GenericResult, ICommandResult
{
    public Guid ReactionId { get; set; }

    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public CommentReaction Reaction { get; set; }

    public ReactToCommentCommandResult() { }

    public ReactToCommentCommandResult(Guid reactionId, Guid commentId, Guid postId, CommentReaction reaction)
    {
        ReactionId = reactionId;
        CommentId = commentId;
        PostId = postId;
        Reaction = reaction;
    }
}