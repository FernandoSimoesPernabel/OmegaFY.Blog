﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Users.Login;
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
    public async Task<IActionResult> RegisterNewUser(RegisterNewUserInputModel inputModel, CancellationToken cancellationToken)
    {
        RegisterNewUserCommand command = inputModel.ToCommand();

        RegisterNewUserCommandResult result =
                        await _serviceBus.SendMessageAsync<RegisterNewUserCommand, RegisterNewUserCommandResult>(command, cancellationToken);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    [ProducesResponseType(typeof(ApiResponse<>), 200)]
    public async Task<IActionResult> Login(LoginInputModel inputModel, CancellationToken cancellationToken)
    {
        LoginCommand command = inputModel.ToCommand();

        LoginCommandResult result = await _serviceBus.SendMessageAsync<LoginCommand, LoginCommandResult>(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete(nameof(Logoff))]
    [ProducesResponseType(typeof(ApiResponse<>), 200)]
    public async Task<IActionResult> Logoff(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost(nameof(RefreshToken))]
    [ProducesResponseType(typeof(ApiResponse<>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
    {
        return Ok();
    }
}