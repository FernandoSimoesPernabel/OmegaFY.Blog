using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Users.Login;
using OmegaFY.Blog.Application.Commands.Users.Logoff;
using OmegaFY.Blog.Application.Commands.Users.RefreshToken;
using OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Models.Commands;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class UsersController : ApiControllerBase<PostsController>
{
    public UsersController(ILogger<PostsController> logger, IServiceBus serviceBus) : base(logger, serviceBus) { }

    [AllowAnonymous]
    [HttpPost(nameof(RegisterNewUser))]
    [ProducesResponseType(typeof(ApiResponse<RegisterNewUserCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    [ProducesResponseType(typeof(ApiResponse), 409)]
    public async Task<IActionResult> RegisterNewUser(RegisterNewUserInputModel inputModel, CancellationToken cancellationToken)
    {
        RegisterNewUserCommand command = inputModel.ToCommand();

        RegisterNewUserCommandResult result =
            await _serviceBus.SendMessageAsync<RegisterNewUserCommand, RegisterNewUserCommandResult>(command, cancellationToken);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    [ProducesResponseType(typeof(ApiResponse<LoginCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> Login(LoginInputModel inputModel, CancellationToken cancellationToken)
    {
        LoginCommand command = inputModel.ToCommand();

        LoginCommandResult result = await _serviceBus.SendMessageAsync<LoginCommand, LoginCommandResult>(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("[action]/{refreshToken:guid}")]
    [ProducesResponseType(typeof(ApiResponse<LogoffCommandResult>), 200)]
    public async Task<IActionResult> Logoff([FromRoute] LogoffInputModel inputModel, CancellationToken cancellationToken)
    {
        LogoffCommand command = inputModel.ToCommand();

        LogoffCommandResult result = await _serviceBus.SendMessageAsync<LogoffCommand, LogoffCommandResult>(command, cancellationToken);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost(nameof(RefreshToken))]
    [ProducesResponseType(typeof(ApiResponse<RefreshTokenCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenInputModel inputModel, CancellationToken cancellationToken)
    {
        RefreshTokenCommand command = inputModel.ToCommand();

        RefreshTokenCommandResult result = await _serviceBus.SendMessageAsync<RefreshTokenCommand, RefreshTokenCommandResult>(command, cancellationToken);

        return Ok(result);
    }
}