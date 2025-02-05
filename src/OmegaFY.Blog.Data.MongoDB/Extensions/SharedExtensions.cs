using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class SharedExtensions
{
    public static SharedCollectionModel[] ToArrayOfSharedCollectionModel(this IReadOnlyCollection<Shared> shareds)
        => shareds.Select(share => share.ToSharedCollectionModel()).ToArray();

    public static SharedCollectionModel ToSharedCollectionModel(this Shared shared)
    {
        return new SharedCollectionModel()
        {
            Id = shared.Id,
            AuthorId = shared.AuthorId,
            PostId = shared.PostId,
            DateAndTimeOfShare = shared.DateAndTimeOfShare
        };
    }
}