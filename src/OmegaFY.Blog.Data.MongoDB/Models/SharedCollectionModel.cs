using MongoDB.Bson;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class SharedCollectionModel
{
    public ObjectId Id { get; set; }

    public ObjectId PostId { get; set; }

    public ObjectId AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}