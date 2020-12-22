using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.WebAPI.Models.QueriesViewModels
{

    public class ListarPostagensRecentesViewModel
    {

        [FromQuery]
        public PagedRequest PagedRequest { get; set; }

    }

}
