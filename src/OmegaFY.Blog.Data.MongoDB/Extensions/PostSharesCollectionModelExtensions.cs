using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostSharesCollectionModelExtensions
{
    public static PostShares ToPostShares(this PostSharesCollectionModel postModel)
        => PostShares.Create(postModel.Id, postModel.Shareds.ToArrayOfShared());
}