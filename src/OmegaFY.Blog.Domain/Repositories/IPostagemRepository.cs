using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Entities.Postagens;
using System;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Repositories
{

    public interface IPostagemRepository : IRepository<Postagem>
    {

        public Task<Postagem> PesquisarPostagemPeloId(Guid id);

        public Task PublicarPostagem(Postagem postagem);

        public void AtualizarDadosPostagem(Postagem postagem);

    }

}
