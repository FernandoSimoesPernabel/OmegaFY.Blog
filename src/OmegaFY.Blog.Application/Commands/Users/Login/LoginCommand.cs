﻿using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Users.Login;

public sealed record class LoginCommand : CommandMediatRBase<LoginCommandResult>
{
    public string Email { get; set; }

    public string Password { internal get; set; }
}