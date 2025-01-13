using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(UsersContext usersContext) : base(usersContext) { }

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken) => await _dbSet.AddAsync(user, cancellationToken);

    public async Task<User> GetByIdAsync(ReferenceId id, CancellationToken cancellationToken) => await _dbSet.FindAsync([id], cancellationToken);

    public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken) => _dbSet.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

    public Task<bool> CheckIfUserAlreadyExistsAsync(string email, CancellationToken cancellationToken) => _dbSet.AnyAsync(x => x.Email == email, cancellationToken);
}