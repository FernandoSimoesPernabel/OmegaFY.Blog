using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

public sealed record class UnsharePostCommand : CommandMediatRBase<UnsharePostCommandResult>
{
    public Guid PostId { get; set; }
}