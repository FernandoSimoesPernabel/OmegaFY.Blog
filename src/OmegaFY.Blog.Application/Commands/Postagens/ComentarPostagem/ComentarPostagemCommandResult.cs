using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.ComentarPostagem
{

    public class ComentarPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid ComentarioId { get; set; }

        public Guid PostagemId { get; set; }

        public Guid UsuarioId { get; set; }

        public ComentarPostagemCommandResult() { }

        public ComentarPostagemCommandResult(Guid comentarioId, Guid postagemId, Guid usuarioId)
        {
            ComentarioId = comentarioId;
            PostagemId = postagemId;
            UsuarioId = usuarioId;
        }

    }

}
