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
        RegisterNewUserCommandResult result = await _serviceBus.SendMessageAsync<RegisterNewUserCommand, RegisterNewUserCommandResult>(inputModel.ToCommand(), cancellationToken);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    [ProducesResponseType(typeof(ApiResponse<LoginCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> Login(LoginInputModel inputModel, CancellationToken cancellationToken)
    {
        LoginCommandResult result = await _serviceBus.SendMessageAsync<LoginCommand, LoginCommandResult>(inputModel.ToCommand(), cancellationToken);
        return Ok(result);
    }

    [HttpDelete("[action]/{refreshToken:guid}")]
    [ProducesResponseType(typeof(ApiResponse<LogoffCommandResult>), 200)]
    public async Task<IActionResult> Logoff([FromRoute] LogoffInputModel inputModel, CancellationToken cancellationToken)
    {
        LogoffCommandResult result = await _serviceBus.SendMessageAsync<LogoffCommand, LogoffCommandResult>(inputModel.ToCommand(), cancellationToken);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost(nameof(RefreshToken))]
    [ProducesResponseType(typeof(ApiResponse<RefreshTokenCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenInputModel inputModel, CancellationToken cancellationToken)
    {
        RefreshTokenCommandResult result = await _serviceBus.SendMessageAsync<RefreshTokenCommand, RefreshTokenCommandResult>(inputModel.ToCommand(), cancellationToken);
        return Ok(result);
    }
}