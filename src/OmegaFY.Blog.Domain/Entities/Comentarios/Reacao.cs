using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class Reacao : EntityWithUserId
    {

        public Guid ComentarioId { get; }

        public Reacoes ReacaoUsuario { get; }

        protected Reacao() { }

        public Reacao(Guid usuarioId, Guid comentarioId, Reacoes reacaoUsuario) : base(usuarioId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarComentarioId(comentarioId)
                .EnsureContractIsValid();

            ComentarioId = comentarioId;
            ReacaoUsuario = reacaoUsuario;
        }

    }

}
