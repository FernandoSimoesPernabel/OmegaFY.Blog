using Flunt.Validations;
using OmegaFY.Blog.Domain.Entities.Comentarios.Base;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;
using System.Collections.Generic;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class Comentario : ComentarioBase, IAggregateRoot
    {

        private readonly SubComentariosColecao _subComentarios;

        public IReadOnlyCollection<SubComentario> SubComentarios => _subComentarios.ReadOnlyCollection;

        public Comentario(Guid usuarioId, Guid postagemId, string comentario) : base(usuarioId, postagemId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .ValidarComentario(comentario)
                .EnsureContractIsValid();

            _subComentarios = new SubComentariosColecao();

            DetalhesModificacao = new DetalhesModificacao();
            Corpo = comentario;
        }

        public void Comentar(string comentario, Guid usuarioId) 
            => _subComentarios.Comentar(new SubComentario(usuarioId, PostagemId, Id, comentario));

        public void RemoverComentario(SubComentario subComentario) => _subComentarios.RemoverComentario(subComentario);

        public int TotalDeComentarios() => _subComentarios.Total();

    }

}
