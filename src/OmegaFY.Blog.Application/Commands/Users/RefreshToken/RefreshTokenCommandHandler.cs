using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Users.RefreshToken;

public class RefreshTokenCommandHandler : CommandHandlerMediatRBase<RefreshTokenCommandHandler, RefreshTokenCommand, RefreshTokenCommandResult>
{
    private readonly IDistributedCache _distributedCache;

    public RefreshTokenCommandHandler(IUserInformation currentUser, ILogger<RefreshTokenCommandHandler> logger, IDistributedCache distributedCache) : base(currentUser, logger)
    {
        _distributedCache = distributedCache;
    }

    public async override Task<RefreshTokenCommandResult> HandleAsync(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}