using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

public class ReactToCommentCommand : CommandMediatRBase<ReactToCommentCommandResult>
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public Reaction Reaction { get; set; }
}