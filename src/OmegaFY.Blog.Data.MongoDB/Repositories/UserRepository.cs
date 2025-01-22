using MongoDB.Bson;
using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class UserRepository : BaseRepository<User, UserCollectionModel>, IUserRepository
{
    protected override string CollectionName => MongoDbContants.USER_COLLECTION;

    public UserRepository(IMongoDatabase database) : base(database) { }

    public async Task<User> GetByIdAsync(ReferenceId id, CancellationToken cancellationToken)
    {
        UserCollectionModel userModel = await _collection.Find(user => user.Id == id).FirstOrDefaultAsync(cancellationToken);
        return userModel?.ToUser();
    }

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        UserCollectionModel userModel = await _collection.Find(user => user.Email == email).FirstOrDefaultAsync(cancellationToken);
        return userModel?.ToUser();
    }

    public Task CreateUserAsync(User user, CancellationToken cancellationToken) 
        => _collection.InsertOneAsync(user.ToUserCollectionModel(), null, cancellationToken);

    public async Task<bool> CheckIfUserAlreadyExistsAsync(string email, CancellationToken cancellationToken)
    {
        long count = await _collection.CountDocumentsAsync(user => user.Email == email, cancellationToken: cancellationToken);
        return count > 0;
    }
}