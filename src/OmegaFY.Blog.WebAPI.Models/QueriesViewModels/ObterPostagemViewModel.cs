using Microsoft.AspNetCore.Mvc;
using System;

namespace OmegaFY.Blog.WebAPI.Models.QueriesViewModels
{

    public class ObterPostagemViewModel
    {
        [FromRoute]
        public Guid Id { get; set; }
    }

}
