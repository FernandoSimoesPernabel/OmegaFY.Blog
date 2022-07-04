using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.Cache.Keys;
using OmegaFY.Blog.Infra.Extensions;

namespace OmegaFY.Blog.Application.Commands.Users.RefreshToken;

public class RefreshTokenCommandHandler : CommandHandlerMediatRBase<RefreshTokenCommandHandler, RefreshTokenCommand, RefreshTokenCommandResult>
{
    private readonly IDistributedCache _distributedCache;

    private readonly IUserRepository _repository;

    private readonly IAuthenticationService _authenticationService;

    public RefreshTokenCommandHandler(
        IUserInformation currentUser,
        ILogger<RefreshTokenCommandHandler> logger,
        IDistributedCache distributedCache,
        IUserRepository repository,
        IAuthenticationService authenticationService) : base(currentUser, logger)
    {
        _distributedCache = distributedCache;
        _repository = repository;
        _authenticationService = authenticationService;
    }

    public async override Task<RefreshTokenCommandResult> HandleAsync(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        User user = await _repository.GetByIdAsync(command.UserId, cancellationToken);

        if (user is null)
            throw new NotFoundException();

        string cacheKey = CacheKeyGenerator.RefreshTokenKey(command.UserId, command.RefreshToken);

        AuthenticationToken? currentToken = await _distributedCache.GetAsync<AuthenticationToken?>(cacheKey, cancellationToken);

        if (!currentToken.HasValue) throw new InvalidOperationException();

        if (command.CurrentToken != currentToken.Value.Token) throw new InvalidOperationException();

        AuthenticationToken newAuthToken =
            await _authenticationService.RefreshTokenAsync(currentToken.Value, new RefreshTokenInput(user.Id, user.Email, user.DisplayName));

        await _distributedCache.SetAuthenticationTokenCacheAsync(user.Id, newAuthToken, cancellationToken);

        return new RefreshTokenCommandResult(
            newAuthToken.Token, 
            newAuthToken.TokenExpirationDate,
            newAuthToken.RefreshToken, 
            newAuthToken.RefreshTokenExpirationDate);
    }
}