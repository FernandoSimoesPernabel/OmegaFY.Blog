using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Core.Repositories
{

    public interface IUnitOfWork
    {

        public Task SaveChangesAsync();

    }

}
