using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Comments.RemoveComment;

public class RemoveCommentCommand : CommandMediatRBase<RemoveCommentCommandResult>
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }
}