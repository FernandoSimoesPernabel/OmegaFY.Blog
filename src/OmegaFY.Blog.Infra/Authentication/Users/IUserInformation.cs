namespace OmegaFY.Blog.Infra.Authentication.Users;

public interface IUserInformation
{
    public Guid? CurrentRequestUserId { get; }

    public string Email { get; }
}