using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;

internal class MakePostPrivateCommandHandler : CommandHandlerMediatRBase<MakePostPrivateCommandHandler, MakePostPrivateCommand, MakePostPrivateCommandResult>
{
    public MakePostPrivateCommandHandler(IUserInformation currentUser, ILogger<MakePostPrivateCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<MakePostPrivateCommandResult> HandleAsync(MakePostPrivateCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
