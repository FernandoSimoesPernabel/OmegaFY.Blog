namespace OmegaFY.Blog.Data.MongoDB.Models;

public class UserCollectionModel
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string DisplayName { get; set; }
}