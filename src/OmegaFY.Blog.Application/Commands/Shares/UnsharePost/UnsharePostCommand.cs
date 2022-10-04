using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

public class UnsharePostCommand : CommandMediatRBase<UnsharePostCommandResult>
{
    public Guid PostId { get; set; }

    public Guid ShareId { get; set; }

    public UnsharePostCommand() { }

    public UnsharePostCommand(Guid postId, Guid shareId)
    {
        PostId = postId;
        ShareId = shareId;
    }
}