using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostAvaliationsCollectionModel
{
    public ReferenceId Id { get; set; }

    public double AverageRate { get; set; }

    public AvaliationCollectionModel[] Avaliations { get; set; } = [];
}