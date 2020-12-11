using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Domain.Core.Repositories;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.UoW
{

    internal class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// Instancia do request que esta sendo utilizada para o ApplicationContext.
        /// </summary>
        private readonly ApplicationContext _applicationContext;

        /// <summary>
        /// Construtor da classe UnitOfWork.
        /// </summary>
        /// <param name="dbContext">Instancia do ApplicationContext para ser injetada via injeção de dependencia.</param>
        public UnitOfWork(ApplicationContext applicationContext) 
            => _applicationContext = applicationContext;

        /// <inheritdoc/>
        public async Task SaveChangesAsync() => await _applicationContext.SaveChangesAsync();

    }

}
