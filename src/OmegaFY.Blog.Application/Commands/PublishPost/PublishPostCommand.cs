using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.PublishPost;

public class PublishPostCommand : CommandMediatRBase<PublishPostCommandResult>
{
    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public PublishPostCommand() { }

    public PublishPostCommand(string title, string subTitle, string body)
    {
        Title = title;
        SubTitle = subTitle;
        Body = body;
    }
}