using OmegaFY.Blog.Domain.Entities;

namespace OmegaFY.Blog.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot<TEntity>
{
}
