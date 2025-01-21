using MongoDB.Bson;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostCollectionModel
{
    public ObjectId Id { get; set; }

    public ObjectId AuthorId { get; set; }

    public Header Header { get; set; }

    public Body Body { get; set; }

    public ModificationDetails ModificationDetails { get; set; }

    public bool Private { get; set; }
}