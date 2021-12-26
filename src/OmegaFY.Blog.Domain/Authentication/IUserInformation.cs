namespace OmegaFY.Blog.Domain.Authentication;

public interface IUserInformation
{
    public Guid CurrentRequestUserId { get; set; }
}