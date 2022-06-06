using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.Cache.Keys;

namespace OmegaFY.Blog.Application.Commands.Users.Logoff;

public class LogoffCommandHandler : CommandHandlerMediatRBase<LogoffCommandHandler, LogoffCommand, LogoffCommandResult>
{
    private readonly IDistributedCache _distributedCache;

    public LogoffCommandHandler(IUserInformation currentUser, ILogger<LogoffCommandHandler> logger, IDistributedCache distributedCache) : base(currentUser, logger)
    {
        _distributedCache = distributedCache;
    }

    public async override Task<LogoffCommandResult> HandleAsync(LogoffCommand command, CancellationToken cancellationToken)
    {
        await _distributedCache.RemoveAsync(CacheKeyGenerator.RefreshTokenKey(_currentUser.CurrentRequestUserId.Value, command.RefreshToken), cancellationToken);

        return new LogoffCommandResult();
    }
}