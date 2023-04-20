using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Posts.PublishPost;

public sealed record class PublishPostCommandResult : GenericResult, ICommandResult
{
    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public string Title { get; }

    public string SubTitle { get; }

    public string Body { get; }

    public DateTime DateOfCreation { get; }

    public PublishPostCommandResult() { }

    public PublishPostCommandResult(Guid postId, Guid authorId, string title, string subTitle, string body, DateTime dateOfCreation)
    {
        PostId = postId;
        AuthorId = authorId;
        Title = title;
        SubTitle = subTitle;
        Body = body;
        DateOfCreation = dateOfCreation;
    }
}