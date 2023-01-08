using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Comments.EditComment;

public class EditCommentCommandResult : GenericResult, ICommandResult
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public string Body { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime DateOfModification { get; set; }
}