using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.Extensions;

namespace OmegaFY.Blog.Application.Commands.Users.Login;

public class LoginCommandHandler : CommandHandlerMediatRBase<LoginCommandHandler, LoginCommand, LoginCommandResult>
{
    private readonly IAuthenticationService _authenticationService;

    private readonly IUserRepository _repository;

    private readonly IDistributedCache _distributedCache;

    public LoginCommandHandler(
        IUserInformation currentUser,
        ILogger<LoginCommandHandler> logger,
        IAuthenticationService authenticationService,
        IUserRepository repository,
        IDistributedCache distributedCache) : base(currentUser, logger)
    {
        _authenticationService = authenticationService;
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public override async Task<LoginCommandResult> HandleAsync(LoginCommand command, CancellationToken cancellationToken)
    {
        User user = await _repository.GetByEmailAsync(command.Email, cancellationToken);

        if (user is null)
            throw new NotFoundException();

        AuthenticationToken authToken = await _authenticationService.LoginAsync(new LoginInput(user.Id, user.Email, command.Password, user.DisplayName));

        await _distributedCache.SetAuthenticationTokenCacheAsync(user.Id, authToken, cancellationToken);

        return new LoginCommandResult(authToken.Token, authToken.TokenExpirationDate, authToken.RefreshToken, authToken.RefreshTokenExpirationDate);
    }
}