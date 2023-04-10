using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;

public sealed record class MakePostPublicCommand : CommandMediatRBase<MakePostPublicCommandResult>
{
    public Guid PostId { get; set; }
}