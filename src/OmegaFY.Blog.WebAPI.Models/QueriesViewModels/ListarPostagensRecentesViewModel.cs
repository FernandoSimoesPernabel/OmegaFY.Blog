using Microsoft.AspNetCore.Mvc;

namespace OmegaFY.Blog.WebAPI.Models.QueriesViewModels
{

    public class ListarPostagensRecentesViewModel
    {

        [FromQuery]
        public int QuantidadeDePostagens { get; set; }

    }

}
