using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Interfaces
{

    public interface IPostagemQuery
    {

        public Task<ObterPostagemQueryResult> ObterPostagemAsync(ObterPostagemQuery query);

    }

}
