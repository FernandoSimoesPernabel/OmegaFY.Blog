namespace OmegaFY.Blog.Infra.Authentication.Configs;

public readonly struct LoginOptions
{
    public Guid UserId { get; }

    public string Email { get; }

    public string Password { get; }

    public string UserName { get; }

    public LoginOptions(Guid userId, string email, string password, string userName)
    {
        UserId = userId;
        Email = email;
        Password = password;
        UserName = userName;
    }
}