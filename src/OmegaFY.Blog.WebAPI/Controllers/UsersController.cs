using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Users.Login;
using OmegaFY.Blog.Application.Commands.Users.Logoff;
using OmegaFY.Blog.Application.Commands.Users.RefreshToken;
using OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class UsersController : ApiControllerBase
{
    public UsersController(IServiceBus serviceBus) : base(serviceBus) { }

    [AllowAnonymous]
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<RegisterNewUserCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    [ProducesResponseType(typeof(ApiResponse), 409)]
    public async Task<IActionResult> RegisterNewUser(RegisterNewUserCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<RegisterNewUserCommand, RegisterNewUserCommandResult>(command, cancellationToken));

    [AllowAnonymous]
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<LoginCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<LoginCommand, LoginCommandResult>(command, cancellationToken));

    [HttpPost("{RefreshToken:guid}")]
    [ProducesResponseType(typeof(ApiResponse<LogoffCommandResult>), 200)]
    public async Task<IActionResult> Logoff([FromRoute] LogoffCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<LogoffCommand, LogoffCommandResult>(command, cancellationToken));

    [AllowAnonymous]
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<RefreshTokenCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<RefreshTokenCommand, RefreshTokenCommandResult>(command, cancellationToken));
}