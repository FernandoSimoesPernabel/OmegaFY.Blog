﻿namespace OmegaFY.Blog.Infra.Authentication.Models;

public readonly struct LoginInput
{
    public Guid UserId { get; }

    public string Email { get; }

    public string Password { get; }

    public string UserName { get; }

    public LoginInput(Guid userId, string email, string password, string userName)
    {
        UserId = userId;
        Email = email;
        Password = password;
        UserName = userName;
    }
}