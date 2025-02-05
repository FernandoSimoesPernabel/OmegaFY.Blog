namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostCommentsCollectionModel
{
    public Guid Id { get; set; }

    public CommentCollectionModel[] Comments { get; set; } = [];
}