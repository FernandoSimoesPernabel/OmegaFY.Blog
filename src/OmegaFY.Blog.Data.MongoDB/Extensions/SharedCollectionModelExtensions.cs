using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class SharedCollectionModelExtensions
{
    public static Shared[] ToArrayOfShared(this SharedCollectionModel[] sharedModels)
        => sharedModels.Select(model => model.ToShared()).ToArray();

    public static Shared ToShared(this SharedCollectionModel sharedModel) 
        => Shared.Create(sharedModel.Id, sharedModel.PostId, sharedModel.AuthorId, sharedModel.DateAndTimeOfShare);
}