using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    protected override string CollectionName => "Users";

    public UserRepository(IMongoDatabase database) : base(database) { }

    public Task<User> GetByIdAsync(ReferenceId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckIfUserAlreadyExistsAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}