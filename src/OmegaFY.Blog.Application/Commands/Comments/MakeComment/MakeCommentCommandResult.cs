using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Comments.MakeComment;

public class MakeCommentCommandResult : GenericResult, ICommandResult
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public string Body { get; set; }

    public DateTime DateOfCreation { get; set; }
}