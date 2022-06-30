using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;

internal class ChangeUserRatingCommandHandler : CommandHandlerMediatRBase<ChangeUserRatingCommandHandler, ChangeUserRatingCommand, ChangeUserRatingCommandResult>
{
    public ChangeUserRatingCommandHandler(IUserInformation currentUser, ILogger<ChangeUserRatingCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<ChangeUserRatingCommandResult> HandleAsync(ChangeUserRatingCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
