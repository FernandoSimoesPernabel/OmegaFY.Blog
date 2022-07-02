using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

internal class RatePostCommandHandler : CommandHandlerMediatRBase<RatePostCommandHandler, RatePostCommand, RatePostCommandResult>
{
    public RatePostCommandHandler(IUserInformation currentUser, ILogger<RatePostCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<RatePostCommandResult> HandleAsync(RatePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
