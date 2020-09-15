using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class Reacao : Entity
    {

        public Guid ComentarioId { get; }

        public Reacoes ReacaoUsuario { get; }

        public Reacao(Guid usuarioId, Guid comentarioId, Reacoes reacaoUsuario)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarComentarioId(comentarioId)
                .EnsureContractIsValid();

            ComentarioId = comentarioId;
            UsuarioId = usuarioId;
            ReacaoUsuario = reacaoUsuario;
        }

    }

}
