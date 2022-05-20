using OmegaFY.Blog.Application.Commands.PublishPost;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class PublishPostViewModel
{
    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public PublishPostCommand ToCommand() => new PublishPostCommand(Title, SubTitle, Body);
}