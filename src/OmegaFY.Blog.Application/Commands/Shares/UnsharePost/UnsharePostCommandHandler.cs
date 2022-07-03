using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

internal class UnsharePostCommandHandler : CommandHandlerMediatRBase<UnsharePostCommandHandler, UnsharePostCommand, UnsharePostCommandResult>
{
    public UnsharePostCommandHandler(IUserInformation currentUser, ILogger<UnsharePostCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<UnsharePostCommandResult> HandleAsync(UnsharePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
