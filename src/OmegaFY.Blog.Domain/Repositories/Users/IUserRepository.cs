using OmegaFY.Blog.Domain.Entities.Users;

namespace OmegaFY.Blog.Domain.Repositories.Users;

public interface IUserRepository : IRepository<User>
{
    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);

    public Task CreateUserAsync(User user, CancellationToken cancellationToken);
}