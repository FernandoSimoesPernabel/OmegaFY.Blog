using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class Reacao : Entity
    {

        public Guid ComentarioId { get; }

        public Guid? SubComentarioId { get; }

        public Guid UsuarioId { get; }

        public Reacoes ReacaoUsuario { get; }

        protected Reacao() { }

        public Reacao(Guid usuarioId, Guid comentarioId, Guid? subComentarioId, Reacoes reacaoUsuario)
        {
            Contract<Reacao> contract = new Contract<Reacao>();

            contract
                .ValidarUsuarioId(usuarioId)
                .ValidarComentarioId(comentarioId)
                .EnsureContractIsValid();

            if (subComentarioId.HasValue)
                contract.ValidarSubComentarioId(subComentarioId.Value).EnsureContractIsValid();

            ComentarioId = comentarioId;
            SubComentarioId = subComentarioId;
            UsuarioId = usuarioId;
            ReacaoUsuario = reacaoUsuario;
        }

    }

}
