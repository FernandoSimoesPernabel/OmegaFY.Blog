using OmegaFY.Blog.Domain.Core.Entities;
using System;

namespace OmegaFY.Blog.Domain.Core.Repositories
{

    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity, IAggregateRoot<TEntity>
    {
    }

}
