using OmegaFY.Blog.Application.Commands.Base;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem
{

    public class CompartilharPostagemCommand : CommandMediatRBase<CompartilharPostagemCommandResult>
    {

        public Guid Id { get; set; }

    }

}
