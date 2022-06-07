﻿using OmegaFY.Blog.Application.Commands.Users.RefreshToken;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class RefreshTokenInputModel
{
    public Guid RefreshToken { get; set; }

    public RefreshTokenCommand ToCommand()
    {
        return new RefreshTokenCommand(RefreshToken);
    }
}