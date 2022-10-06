using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Domain.Entities;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.EF.Repositories.Base;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot<TEntity>
{
    protected readonly DbContext _context;

    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext dbContext)
    {
        _context = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
}