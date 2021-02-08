using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario;
using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Interfaces
{

    public interface IPostagemQuery
    {

        public Task<ObterPostagemQueryResult> ObterPostagemAsync(ObterPostagemQuery query);

        public Task<ListarPostagensRecentesQueryResult> ListarPostagensRecentesAsync(ListarPostagensRecentesQuery query);

        public Task<ListarPostagensPorUsuarioQueryResult> ListarPostagensPorUsuarioAsync(ListarPostagensPorUsuarioQuery query);

    }

}
