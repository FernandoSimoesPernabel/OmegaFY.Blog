using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Domain.Repositories
{

    public interface IPostagemRepository : IRepository<Postagem>, IUnitOfWork
    {

        public void PublicarPostagem(Postagem postagem);

    }

}
