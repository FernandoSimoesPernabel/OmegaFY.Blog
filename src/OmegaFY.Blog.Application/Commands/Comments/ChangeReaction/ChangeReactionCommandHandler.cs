using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.ChangeReaction;

internal class ChangeReactionCommandHandler : CommandHandlerMediatRBase<ChangeReactionCommandHandler, ChangeReactionCommand, ChangeReactionCommandResult>
{
    public ChangeReactionCommandHandler(IUserInformation currentUser, ILogger<ChangeReactionCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<ChangeReactionCommandResult> HandleAsync(ChangeReactionCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
