using OmegaFY.Blog.Application.Queries.Base;
using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario
{

    public class ListarPostagensPorUsuarioQuery : QueryRequestMediatRBase<ListarPostagensPorUsuarioQueryResult>
    {

        public Guid UsuarioId { get; set; }

        public PagedRequest PagedRequest { get; set; }

    }

}
