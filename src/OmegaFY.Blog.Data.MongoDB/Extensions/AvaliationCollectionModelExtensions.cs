using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class AvaliationCollectionModelExtensions
{
    public static Avaliation[] ToArrayOfAvaliation(this AvaliationCollectionModel[] avaliationModels)
        => avaliationModels.Select(avaliationModel => avaliationModel.ToAvaliation()).ToArray();

    public static Avaliation ToAvaliation(this AvaliationCollectionModel avaliationModel)
    {
        return Avaliation.Create(
            avaliationModel.Id, 
            avaliationModel.PostId,
            avaliationModel.AuthorId, 
            new ModificationDetails(avaliationModel.DateOfCreation, avaliationModel.DateOfModification), 
            avaliationModel.Rate);
    }
}