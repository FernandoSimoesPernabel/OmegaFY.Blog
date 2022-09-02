using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;

public class ChangePostContentCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public ChangePostContentCommandResult() { }

    public ChangePostContentCommandResult(Guid id, Guid authorId, string title, string subTitle, string body, DateTime creationDate, DateTime modificationDate)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        SubTitle = subTitle;
        Body = body;
        CreationDate = creationDate;
        ModificationDate = modificationDate;
    }
}