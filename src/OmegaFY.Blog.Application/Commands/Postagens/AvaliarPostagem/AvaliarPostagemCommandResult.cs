using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.AvaliarPostagem
{

    public class AvaliarPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid AvaliacaoId { get; set; }

        public Guid PostagemId { get; set; }

        public Guid UsuarioId { get; set; }

        public AvaliarPostagemCommandResult() { }

        public AvaliarPostagemCommandResult(Guid avaliacaoId, Guid postagemId, Guid usuarioId)
        {
            AvaliacaoId = avaliacaoId;
            PostagemId = postagemId;
            UsuarioId = usuarioId;
        }

    }

}
