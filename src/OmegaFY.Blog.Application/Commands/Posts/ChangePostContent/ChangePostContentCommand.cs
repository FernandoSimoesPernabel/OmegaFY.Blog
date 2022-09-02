using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;

namespace OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;

public class ChangePostContentCommand : CommandMediatRBase<ChangePostContentCommandResult>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public ChangePostContentCommand() { }

    public ChangePostContentCommand(Guid id, string title, string subTitle, string body)
    {
        Id = id;
        Title = title;
        SubTitle = subTitle;
        Body = body;
    }
}