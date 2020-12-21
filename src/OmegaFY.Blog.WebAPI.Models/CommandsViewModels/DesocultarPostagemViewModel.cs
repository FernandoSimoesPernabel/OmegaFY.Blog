using Microsoft.AspNetCore.Mvc;
using System;

namespace OmegaFY.Blog.WebAPI.Models.CommandsViewModels
{

    public class DesocultarPostagemViewModel
    {

        [FromRoute]
        public Guid Id { get; set; }

    }

}
