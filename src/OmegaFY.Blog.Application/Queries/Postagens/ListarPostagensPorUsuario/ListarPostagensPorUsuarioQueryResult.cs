using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario.DTOs;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario
{

    public class ListarPostagensPorUsuarioQueryResult : PagedResult
    {

        public IEnumerable<PostagensDoUsuarioDTO> PostagensDoUsuario { get; set; }

        public ListarPostagensPorUsuarioQueryResult(PagedResultInfo resultInfo) : base(resultInfo) { }

    }

}
