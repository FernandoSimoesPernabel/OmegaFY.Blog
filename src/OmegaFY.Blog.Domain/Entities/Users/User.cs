using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Users;

public class User : Entity, IAggregateRoot<User>
{
    public string Email { get; }

    public string DisplayName { get; private set; }

    public User(string email, string displayName)
    {
        Email = email;
        DisplayName = displayName;
    }
}