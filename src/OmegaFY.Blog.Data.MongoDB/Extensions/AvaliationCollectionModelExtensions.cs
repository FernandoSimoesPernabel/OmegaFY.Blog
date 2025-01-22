using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Avaliations;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class AvaliationCollectionModelExtensions
{
    public static Avaliation[] ToArrayOfAvaliation(this AvaliationCollectionModel[] avaliationModels)
        => avaliationModels.Select(avaliationModel => avaliationModel.ToAvaliation()).ToArray();

    public static Avaliation ToAvaliation(this AvaliationCollectionModel avaliationModel) 
        => Avaliation.Create(avaliationModel.Id.ToGuid(), avaliationModel.PostId.ToGuid(), avaliationModel.AuthorId.ToGuid(), avaliationModel.Rate);
}