using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Avaliations;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class AvaliationExtensions
{
    public static AvaliationCollectionModel[] ToArrayOfAvaliationCollectionModel(this IReadOnlyCollection<Avaliation> avaliations)
        => avaliations.Select(avaliation => avaliation.ToAvaliationCollectionModel()).ToArray();

    public static AvaliationCollectionModel ToAvaliationCollectionModel(this Avaliation avaliation)
    {
        return new AvaliationCollectionModel()
        {
            Id = avaliation.Id.ToObjectId(),
            AuthorId = avaliation.AuthorId.ToObjectId(),
            PostId = avaliation.PostId.ToObjectId(),
            ModificationDetails = avaliation.ModificationDetails,
            Rate = avaliation.Rate
        };
    }
}