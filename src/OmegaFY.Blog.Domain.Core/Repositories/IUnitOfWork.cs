using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Core.Repositories
{

    public interface IUnitOfWork
    {

        /// <summary>
        /// Aplica efetivamente as alterações na base de dados.
        /// </summary>
        public Task SaveChangesAsync();

    }

}
