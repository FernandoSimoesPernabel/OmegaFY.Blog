using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes.DTOs;
using OmegaFY.Blog.Domain.Core.Queries;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes
{

    public class ListarPostagensRecentesQueryResult : PagedResult, IQueryResult
    {

        public IEnumerable<PostagensRecentesDTO> PostagensRecentes { get; set; }

        public ListarPostagensRecentesQueryResult() { }

        public ListarPostagensRecentesQueryResult(PagedResultInfo resultInfo) : base(resultInfo) { }

    }

}
