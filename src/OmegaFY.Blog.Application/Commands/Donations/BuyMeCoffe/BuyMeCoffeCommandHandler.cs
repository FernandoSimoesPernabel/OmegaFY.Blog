using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Donations.BuyMeCoffe;

internal class BuyMeCoffeCommandHandler : CommandHandlerMediatRBase<BuyMeCoffeCommandHandler, BuyMeCoffeCommand, BuyMeCoffeCommandResult>
{
    public BuyMeCoffeCommandHandler(IUserInformation currentUser, ILogger<BuyMeCoffeCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<BuyMeCoffeCommandResult> HandleAsync(BuyMeCoffeCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
