using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.RemoveReaction;

internal class RemoveReactionCommandHandler : CommandHandlerMediatRBase<RemoveReactionCommandHandler, RemoveReactionCommand, RemoveReactionCommandResult>
{
    public RemoveReactionCommandHandler(IUserInformation currentUser, ILogger<RemoveReactionCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<RemoveReactionCommandResult> HandleAsync(RemoveReactionCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
