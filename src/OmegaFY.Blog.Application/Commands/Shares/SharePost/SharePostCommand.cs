using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

public class SharePostCommand : CommandMediatRBase<SharePostCommandResult>
{
    public Guid Id { get; set; }

    public SharePostCommand() { }

    public SharePostCommand(Guid id)
    {
        Id = id;
    }
}