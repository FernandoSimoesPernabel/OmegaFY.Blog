using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Comments.MakeComment;

public sealed record class MakeCommentCommandResult : GenericResult, ICommandResult
{
    public Guid CommentId { get; }

    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public string Body { get; }

    public DateTime DateOfCreation { get; }

    public MakeCommentCommandResult(Guid commentId, Guid postId, Guid authorId, string body, DateTime dateOfCreation)
    {
        CommentId = commentId;
        PostId = postId;
        AuthorId = authorId;
        Body = body;
        DateOfCreation = dateOfCreation;
    }
}