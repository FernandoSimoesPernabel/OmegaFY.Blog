using OmegaFY.Blog.Domain.Commands;
using OmegaFY.Blog.Domain.Result.Base;

namespace OmegaFY.Blog.Application.Commands.PublishPost;

public class PublishPostCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public DateTime CreationDate { get; set; }

    public PublishPostCommandResult() { }

    public PublishPostCommandResult(Guid id, Guid authorId, string title, string subTitle, string body, DateTime creationDate)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        SubTitle = subTitle;
        Body = body;
        CreationDate = creationDate;
    }
}