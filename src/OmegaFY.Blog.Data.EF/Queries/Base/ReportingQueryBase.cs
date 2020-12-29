using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities;

namespace OmegaFY.Blog.Data.EF.Queries.Base
{

    public abstract class ReportingQueryBase<T> where T : Entity
    {

        /// <summary>
        /// DbSet referente a entidade ao qual o repositorio é responsavel.
        /// </summary>
        protected readonly DbSet<T> _dbSet;

        protected readonly IMapperServices _mapper;

        /// <summary>
        /// Construtor da classe base.
        /// </summary>
        /// <param name="dbContext">Contexto referente ao banco de dados.</param>
        public ReportingQueryBase(DbContext dbContext, IMapperServices mapper)
        {
            _dbSet = dbContext.Set<T>();
            _mapper = mapper;
        }

    }

}
