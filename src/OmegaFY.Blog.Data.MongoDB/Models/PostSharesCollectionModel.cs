using MongoDB.Bson;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostSharesCollectionModel
{
    public ObjectId Id { get; set; }

    public SharedCollectionModel[] Shareds { get; set; } = [];
}