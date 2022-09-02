using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;

public class MakePostPrivateCommand : CommandMediatRBase<MakePostPrivateCommandResult>
{
    public Guid Id { get; set; }

    public MakePostPrivateCommand() { }

    public MakePostPrivateCommand(Guid id)
    {
        Id = id;
    }
}