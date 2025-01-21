using MongoDB.Bson;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostCommentsCollectionModel
{
    public ObjectId Id { get; set; }

    public CommentCollectionModel[] Comments { get; set; } = [];
}