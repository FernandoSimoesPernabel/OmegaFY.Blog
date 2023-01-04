using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Comments.MakeComment;

public class MakeCommentCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }
}