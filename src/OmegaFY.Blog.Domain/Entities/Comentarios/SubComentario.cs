using Flunt.Validations;
using OmegaFY.Blog.Domain.Entities.Comentarios.Base;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class SubComentario : ComentarioBase
    {

        public Guid ComentarioId { get; }

        protected SubComentario() { }

        public SubComentario(Guid usuarioId, Guid postagemId, Guid comentarioId, string comentario) : base(usuarioId, postagemId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .ValidarComentarioId(comentarioId)
                .ValidarComentario(comentario)
                .EnsureContractIsValid();

            ComentarioId = comentarioId;
            DetalhesModificacao = new DetalhesModificacao();
            Corpo = comentario;
        }

    }

}
