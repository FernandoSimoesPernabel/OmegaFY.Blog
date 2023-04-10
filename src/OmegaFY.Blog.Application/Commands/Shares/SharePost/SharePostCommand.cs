using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

public sealed record class SharePostCommand : CommandMediatRBase<SharePostCommandResult>
{
    public Guid PostId { get; set; }
}