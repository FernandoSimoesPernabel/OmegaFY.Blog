using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Comments.EditComment;

public sealed record class EditCommentCommandResult : GenericResult, ICommandResult
{
    public Guid CommentId { get; }

    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public string Content { get; }

    public DateTime DateOfCreation { get; }

    public DateTime DateOfModification { get; }

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