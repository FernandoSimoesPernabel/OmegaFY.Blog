using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;

public sealed record class ChangePostContentCommand : CommandMediatRBase<ChangePostContentCommandResult>
{
    public Guid PostId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }
}