using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;

public sealed record class ChangePostContentCommandResult : GenericResult, ICommandResult
{
    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public string Title { get; }

    public string SubTitle { get; }

    public string Body { get; }

    public DateTime DateOfCreation { get; }

    public DateTime DateOfModification { get; }

    public ChangePostContentCommandResult(
        Guid postId,
        Guid authorId,
        string title,
        string subTitle,
        string body,
        DateTime dateOfCreation,
        DateTime dateOfModification)
    {
        PostId = postId;
        AuthorId = authorId;
        Title = title;
        SubTitle = subTitle;
        Body = body;
        DateOfCreation = dateOfCreation;
        DateOfModification = dateOfModification;
    }
}