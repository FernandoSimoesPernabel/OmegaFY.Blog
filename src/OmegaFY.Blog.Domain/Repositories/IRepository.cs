using OmegaFY.Blog.Domain.Entities;
using System;

namespace OmegaFY.Blog.Domain.Repositories
{

    public interface IRepository<T> : IDisposable where T : Entity, IAggregateRoot
    {

    }

}
