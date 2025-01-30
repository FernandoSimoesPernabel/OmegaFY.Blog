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
            Id = avaliation.Id,
            AuthorId = avaliation.AuthorId,
            DateOfCreation  = avaliation.ModificationDetails.DateOfCreation,
            DateOfModification = avaliation.ModificationDetails.DateOfModification,
            PostId = avaliation.PostId,
            Rate = avaliation.Rate
        };
    }
}