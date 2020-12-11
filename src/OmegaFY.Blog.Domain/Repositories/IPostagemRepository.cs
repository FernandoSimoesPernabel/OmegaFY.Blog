using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Entities.Postagens;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Repositories
{

    public interface IPostagemRepository : IRepository<Postagem>
    {

        public Task PublicarPostagem(Postagem postagem);

    }

}
