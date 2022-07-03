using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.UnhidePost;

internal class UnhidePostCommandHandler : CommandHandlerMediatRBase<UnhidePostCommandHandler, UnhidePostCommand, UnhidePostCommandResult>
{
    public UnhidePostCommandHandler(IUserInformation currentUser, ILogger<UnhidePostCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<UnhidePostCommandResult> HandleAsync(UnhidePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
