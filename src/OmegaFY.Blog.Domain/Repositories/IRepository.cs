using OmegaFY.Blog.Domain.Entities;

namespace OmegaFY.Blog.Domain.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : IEntity, IAggregateRoot<TEntity>
{
}
