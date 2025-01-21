using MongoDB.Bson;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class AvaliationCollectionModel
{
    public ObjectId Id { get; set; }

    public ObjectId PostId { get; set; }

    public ObjectId AuthorId { get; set; }

    public ModificationDetails ModificationDetails { get; set; }

    public Stars Rate { get; set; }
}