using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

public class ReactToCommentCommandResult : GenericResult, ICommandResult
{
    public Guid ReactionId { get; set; }

    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public Reaction Reaction { get; set; }
}