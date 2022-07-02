using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Application.Commands.Users.ExcludeAccount;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Users.ExcludeAccount;

internal class ExcludeAccountCommandHandler : CommandHandlerMediatRBase<ExcludeAccountCommandHandler, ExcludeAccountCommand, ExcludeAccountCommandResult>
{
    public ExcludeAccountCommandHandler(IUserInformation currentUser, ILogger<ExcludeAccountCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<ExcludeAccountCommandResult> HandleAsync(ExcludeAccountCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
