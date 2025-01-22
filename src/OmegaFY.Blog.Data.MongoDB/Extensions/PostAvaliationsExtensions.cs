using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Avaliations;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostAvaliationsExtensions
{
    public static PostAvaliationsCollectionModel ToPostAvaliationsCollectionModel(this PostAvaliations postAvaliations)
    {
        return new PostAvaliationsCollectionModel()
        {
            Id = postAvaliations.Id,
            Avaliations = postAvaliations.Avaliations.ToArrayOfAvaliationCollectionModel(),
            AverageRate = postAvaliations.AverageRate
        };
    }
}