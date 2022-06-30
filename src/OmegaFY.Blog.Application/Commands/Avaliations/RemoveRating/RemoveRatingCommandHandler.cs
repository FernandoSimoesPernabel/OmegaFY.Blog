using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;

internal class RemoveRatingCommandHandler : CommandHandlerMediatRBase<RemoveRatingCommandHandler, RemoveRatingCommand, RemoveRatingCommandResult>
{
    public RemoveRatingCommandHandler(IUserInformation currentUser, ILogger<RemoveRatingCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<RemoveRatingCommandResult> HandleAsync(RemoveRatingCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
