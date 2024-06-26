﻿using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Users.Logoff;

public sealed record class LogoffCommand : CommandMediatRBase<LogoffCommandResult>
{
    public Guid RefreshToken { get; set; }
}