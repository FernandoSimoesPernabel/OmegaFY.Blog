using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Comments.EditComment;

public class EditCommentCommandResult : GenericResult, ICommandResult
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime DateOfModification { get; set; }

    public EditCommentCommandResult() { }

    public EditCommentCommandResult(Guid commentId, Guid postId, Guid authorId, string content, DateTime dateOfCreation, DateTime dateOfModification)
    {
        CommentId = commentId;
        PostId = postId;
        AuthorId = authorId;
        Content = content;
        DateOfCreation = dateOfCreation;
        DateOfModification = dateOfModification;
    }
}