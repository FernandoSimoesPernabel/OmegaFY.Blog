﻿using OmegaFY.Blog.Domain.Core.Entities;
using System;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Core.Repositories
{

    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity, IAggregateRoot<TEntity>
    {

        public Task<int> SaveChangesAsync();

    }

}
