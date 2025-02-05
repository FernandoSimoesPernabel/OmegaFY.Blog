namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostSharesCollectionModel
{
    public Guid Id { get; set; }

    public SharedCollectionModel[] Shareds { get; set; } = [];
}