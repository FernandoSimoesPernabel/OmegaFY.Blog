using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes
{

    public class ListarPostagensRecentesQuery : QueryRequestMediatRBase<ListarPostagensRecentesQueryResult>
    {

        public PagedRequest PagedRequest { get; set; }

    }

}
