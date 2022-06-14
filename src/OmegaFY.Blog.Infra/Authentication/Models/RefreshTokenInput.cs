namespace OmegaFY.Blog.Infra.Authentication.Models;

public readonly struct RefreshTokenInput
{
    public Guid UserId { get; }

    public string Email { get; }

    public string UserName { get; }

    public RefreshTokenInput(Guid userId, string email, string userName)
    {
        UserId = userId;
        Email = email;
        UserName = userName;
    }
}