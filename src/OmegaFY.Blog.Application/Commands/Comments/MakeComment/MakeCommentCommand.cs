using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Comments.MakeComment;

public class MakeCommentCommand : CommandMediatRBase<MakeCommentCommandResult>
{
    public Guid PostId { get; set; }

    public string Content { get; set; }
}