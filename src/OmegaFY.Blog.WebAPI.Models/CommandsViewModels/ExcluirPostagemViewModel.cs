using Microsoft.AspNetCore.Mvc;
using System;

namespace OmegaFY.Blog.WebAPI.Models.CommandsViewModels
{

    public class ExcluirPostagemViewModel
    {

        [FromRoute]
        public Guid Id { get; set; }

    }

}
