using MongoDB.Driver;
using OmegaFY.Blog.Domain.Entities;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.MongoDB.Repositories.Base;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot<TEntity>
{
    protected readonly IMongoDatabase _database;

    protected readonly IMongoCollection<TEntity> _collection;

    protected abstract string CollectionName { get; }

    public BaseRepository(IMongoDatabase database)
    {
        _database = database;
        _collection = database.GetCollection<TEntity>(CollectionName);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}