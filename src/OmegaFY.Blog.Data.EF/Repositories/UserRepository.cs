﻿using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Repositories.Users;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(UsersContext usersContext) : base(usersContext) { }

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken) => await _dbSet.AddAsync(user, cancellationToken);

    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken) => await _dbSet.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
}