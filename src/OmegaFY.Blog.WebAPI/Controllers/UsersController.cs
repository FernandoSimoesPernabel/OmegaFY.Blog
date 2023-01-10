using Asp.Versioning;
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
    [ProducesResponseType(typeof(ApiResponse<RegisterNewUserCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> RegisterNewUser(RegisterNewUserCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<RegisterNewUserCommand, RegisterNewUserCommandResult>(command, cancellationToken));

    [AllowAnonymous]
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<LoginCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<LoginCommand, LoginCommandResult>(command, cancellationToken));

    [HttpPost("{RefreshToken:guid}")]
    [ProducesResponseType(typeof(ApiResponse<LogoffCommandResult>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Logoff([FromRoute] LogoffCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<LogoffCommand, LogoffCommandResult>(command, cancellationToken));

    [AllowAnonymous]
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<RefreshTokenCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<RefreshTokenCommand, RefreshTokenCommandResult>(command, cancellationToken));
}