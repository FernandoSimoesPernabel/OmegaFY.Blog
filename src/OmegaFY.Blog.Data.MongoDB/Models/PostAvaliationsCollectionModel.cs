namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostAvaliationsCollectionModel
{
    public Guid Id { get; set; }

    public double AverageRate { get; set; }

    public AvaliationCollectionModel[] Avaliations { get; set; } = [];
}