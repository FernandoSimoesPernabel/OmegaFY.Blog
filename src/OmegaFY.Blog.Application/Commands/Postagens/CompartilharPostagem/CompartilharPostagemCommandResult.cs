using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem
{

    public class CompartilharPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid IdCompartilhamento { get; set; }

        public Guid IdPostagem { get; set; }

        public Guid IdUsuario { get; set; }

        public CompartilharPostagemCommandResult()
        {

        }

        public CompartilharPostagemCommandResult(Guid idCompartilhamento, Guid idPostagem, Guid idUsuario)
        {
            IdCompartilhamento = idCompartilhamento;
            IdPostagem = idPostagem;
            IdUsuario = idUsuario;
        }

    }

}
