using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem
{

    public class CompartilharPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid CompartilhamentoId { get; set; }

        public Guid PostagemId { get; set; }

        public Guid UsuarioId { get; set; }

        public CompartilharPostagemCommandResult() { }

        public CompartilharPostagemCommandResult(Guid compartilhamentoId, Guid postagemId, Guid usuarioId)
        {
            CompartilhamentoId = compartilhamentoId;
            PostagemId = postagemId;
            UsuarioId = usuarioId;
        }

    }

}
