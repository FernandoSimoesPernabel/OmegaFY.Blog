using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Models;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class IMongoCollectionExtensions
{
    public async static Task HydrateAuthorNameAsync<TCollection>(
        this IMongoCollection<UserCollectionModel> userCollection,
        TCollection item,
        Guid userId,
        Action<TCollection, UserCollectionModel> funcFillAuthorName,
        CancellationToken cancellationToken)
    {
        UserCollectionModel user = await userCollection.Find(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);
        funcFillAuthorName(item, user);
    }

    public async static Task HydrateAuthorNamesAsync<TCollection>(
        this IMongoCollection<UserCollectionModel> userCollection,
        TCollection[] items,
        Func<TCollection[], Guid[]> funcGetUserIds,
        Action<TCollection[], UserCollectionModel[]> funcFillAuthorName,
        CancellationToken cancellationToken)
    {
        Guid[] userIds = funcGetUserIds(items);

        UserCollectionModel[] users = await userCollection.Find(user => userIds.Contains(user.Id)).ToArrayAsync(cancellationToken);

        funcFillAuthorName(items, users);
    }
}