﻿using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Users;

public class User : Entity, IAggregateRoot<User>
{
    public string Email { get; }

    public string DisplayName { get; private set; }

    protected User() { }

    private User(ReferenceId userId, string email, string displayName) : base(userId)
    {
        Email = email;
        DisplayName = displayName;
    }

    public User(string email, string displayName)
    {
        if (string.IsNullOrWhiteSpace(email) || email.Length > UserConstants.MAX_EMAIL_LENGTH)
            throw new DomainArgumentException("O Email informado esta inválido.");

        Email = email;
        ChangeDisplayName(displayName);
    }

    public void ChangeDisplayName(string displayName)
    {
        if (string.IsNullOrWhiteSpace(displayName))
            throw new DomainArgumentException("Não foi informado um nome para o usuário");

        if (displayName.Length < UserConstants.MIN_DISPLAY_NAME_LENGTH || displayName.Length > UserConstants.MAX_DISPLAY_NAME_LENGTH)
            throw new DomainArgumentException($"O nome de usuário deve ter entre {UserConstants.MIN_DISPLAY_NAME_LENGTH} e {UserConstants.MAX_DISPLAY_NAME_LENGTH}.");

        DisplayName = displayName;
    }

    public static User Create(ReferenceId userId, string email, string displayName) => new User(userId, email, displayName);
}