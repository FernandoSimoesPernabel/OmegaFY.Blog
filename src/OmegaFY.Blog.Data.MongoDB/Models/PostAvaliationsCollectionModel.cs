using MongoDB.Bson;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostAvaliationsCollectionModel
{
    public ObjectId Id { get; set; }

    public double AverageRate { get; set; }

    public AvaliationCollectionModel[] Avaliations { get; set; } = [];
}