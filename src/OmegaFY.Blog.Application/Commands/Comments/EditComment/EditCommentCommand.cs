using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Comments.EditComment;

public sealed record class EditCommentCommand : CommandMediatRBase<EditCommentCommandResult>
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public string NewContent { get; set; }
}