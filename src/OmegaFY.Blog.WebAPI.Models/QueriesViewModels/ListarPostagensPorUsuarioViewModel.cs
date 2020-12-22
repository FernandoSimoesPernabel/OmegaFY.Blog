using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Queries.Base;
using System;

namespace OmegaFY.Blog.WebAPI.Models.QueriesViewModels
{

    public class ListarPostagensPorUsuarioViewModel
    {

        [FromRoute]
        public Guid UsuarioId { get; set; }

        [FromQuery]
        public PagedRequest PagedRequest { get; set; }

    }

}
