using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.Extensions;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public class RegisterNewUserCommandHandler : CommandHandlerMediatRBase<RegisterNewUserCommandHandler, RegisterNewUserCommand, RegisterNewUserCommandResult>
{
    private readonly IAuthenticationService _authenticationService;

    private readonly IUserRepository _repository;

    private readonly IDistributedCache _distributedCache;

    public RegisterNewUserCommandHandler(
        IUserInformation currentUser,
        ILogger<RegisterNewUserCommandHandler> logger,
        IAuthenticationService authenticationService,
        IUserRepository repository,
        IDistributedCache distributedCache) : base(currentUser, logger)
    {
        _authenticationService = authenticationService;
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public override async Task<RegisterNewUserCommandResult> HandleAsync(RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        User newUser = new User(command.Email, command.DisplayName);

        await _repository.CreateUserAsync(newUser, cancellationToken);

        AuthenticationToken authToken = await _authenticationService.RegisterNewUserAsync(
            new LoginInput(newUser.Id, newUser.Email, command.Password, newUser.DisplayName),
            cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        await _distributedCache.SetAuthenticationTokenCacheAsync(authToken, cancellationToken);

        return new RegisterNewUserCommandResult(newUser.Id, authToken.Token, authToken.TokenExpirationDate, authToken.RefreshToken, authToken.RefreshTokenExpirationDate);
    }
}