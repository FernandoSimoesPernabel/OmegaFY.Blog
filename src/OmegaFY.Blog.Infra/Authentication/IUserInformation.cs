namespace OmegaFY.Blog.Infra.Authentication;

public interface IUserInformation
{
    public Guid CurrentRequestUserId { get; }
}