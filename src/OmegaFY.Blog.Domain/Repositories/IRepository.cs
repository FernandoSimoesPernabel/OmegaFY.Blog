using OmegaFY.Blog.Domain.Entities;

namespace OmegaFY.Blog.Domain.Repositories;

public interface IRepository<TEntity> : IUnitOfWork where TEntity : Entity, IAggregateRoot<TEntity>
{
}
