using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem
{

    public class PublicarPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public PublicarPostagemCommandResult() : base() { }

        public PublicarPostagemCommandResult(Guid id, Guid usuarioId)
        {
            Id = id;
            UsuarioId = usuarioId;
        }

    }

}