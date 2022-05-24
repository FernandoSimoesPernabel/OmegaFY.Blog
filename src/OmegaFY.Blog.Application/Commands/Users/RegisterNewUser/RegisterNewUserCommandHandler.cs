using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Infra.Authentication;

namespace OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;

public class RegisterNewUserCommandHandler : CommandHandlerMediatRBase<RegisterNewUserCommandHandler, RegisterNewUserCommand, RegisterNewUserCommandResult>
{
    private readonly IAuthenticationService _authenticationService;

    private readonly IUserRepository _userRepository;

    public RegisterNewUserCommandHandler(
        IUserInformation currentUser,
        ILogger<RegisterNewUserCommandHandler> logger,
        IAuthenticationService authenticationService,
        IUserRepository userRepository) : base(currentUser, logger)
    {
        _authenticationService = authenticationService;
        _userRepository = userRepository;
    }

    public override async Task<RegisterNewUserCommandResult> HandleAsync(RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        User newUser = new User(command.Email, command.DisplayName);

        await _userRepository.CreateUserAsync(newUser, cancellationToken);

        await _authenticationService.RegisterNewUserAsync(command.Email, command.Password, cancellationToken);

        await _userRepository.SaveChangesAsync(cancellationToken);

        return new RegisterNewUserCommandResult(newUser.Id);
    }
}