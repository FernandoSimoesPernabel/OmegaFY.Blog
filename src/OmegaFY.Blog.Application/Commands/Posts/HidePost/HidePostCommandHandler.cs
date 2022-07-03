using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.HidePost;

internal class HidePostCommandHandler : CommandHandlerMediatRBase<HidePostCommandHandler, HidePostCommand, HidePostCommandResult>
{
    public HidePostCommandHandler(IUserInformation currentUser, ILogger<HidePostCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<HidePostCommandResult> HandleAsync(HidePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
