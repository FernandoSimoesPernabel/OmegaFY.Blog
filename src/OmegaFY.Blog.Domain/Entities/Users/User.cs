using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Users;

public class User : Entity, IAggregateRoot<User>
{
    public string Email { get; }

    public string DisplayName { get; private set; }

    public User(string email, string displayName)
    {
        if (string.IsNullOrWhiteSpace(email) || email.Length > UserConstants.MAX_EMAIL_LENGTH)
            throw new DomainArgumentException("");

        ChangeDisplayName(displayName);

        Email = email;
    }

    private void ChangeDisplayName(string displayName)
    {
        if (string.IsNullOrWhiteSpace(displayName))
            throw new DomainArgumentException("");

        if (displayName.Length < UserConstants.MIN_DISPLAY_NAME_LENGTH || displayName.Length > UserConstants.MAX_DISPLAY_NAME_LENGTH)
            throw new DomainArgumentException("");

        DisplayName = displayName;
    }
}