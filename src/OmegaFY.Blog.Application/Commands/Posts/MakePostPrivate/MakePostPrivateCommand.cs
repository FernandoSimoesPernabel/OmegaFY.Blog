using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;

public sealed record class MakePostPrivateCommand : CommandMediatRBase<MakePostPrivateCommandResult>
{
    public Guid PostId { get; set; }
}