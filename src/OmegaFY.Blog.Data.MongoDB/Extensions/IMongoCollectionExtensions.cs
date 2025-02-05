using MongoDB.Bson;
using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Models;
using System.Linq.Expressions;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class IMongoCollectionExtensions
{
    public static async Task<long> AggregateCountAsync<TCollection>(this IMongoCollection<TCollection> collection, Expression<Func<TCollection, object>> field, CancellationToken cancellationToken) 
        => await collection.AggregateCountAsync(Builders<TCollection>.Filter.Empty, field, cancellationToken);

    public static async Task<long> AggregateCountAsync<TCollection>(
        this IMongoCollection<TCollection> collection,
        FilterDefinition<TCollection> filter,
        Expression<Func<TCollection, object>> field,
        CancellationToken cancellationToken)
    {
        AggregateCountResult result = 
            await collection.Aggregate().Match(filter).Unwind<TCollection, BsonDocument>(field).Count().FirstOrDefaultAsync(cancellationToken);

        return result?.Count ?? 0;
    }

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