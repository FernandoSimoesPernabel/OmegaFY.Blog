using Flunt.Validations;
using OmegaFY.Blog.Domain.Entities.Comentarios.Base;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class Comentario : ComentarioBase
    {

        private readonly List<SubComentario> _subComentarios;

        public IReadOnlyCollection<SubComentario> SubComentarios => _subComentarios.AsReadOnly();

        protected Comentario() { }

        public Comentario(Guid usuarioId, Guid postagemId, Corpo comentario) : base(usuarioId, postagemId)
        {
            new Contract<Comentario>()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .ValidarComentario(comentario)
                .EnsureContractIsValid();

            _subComentarios = new List<SubComentario>();

            DetalhesModificacao = new DetalhesModificacao();
            Corpo = comentario;
        }

        internal void Comentar(SubComentario subComentario)
        {
            new Contract<Comentario>()
                .IsNotNull(subComentario, nameof(subComentario), "Não foi informado nenhum SubComentário.")
                .EnsureContractIsValid();

            _subComentarios.Add(subComentario);
        }

        internal void EditarSubComentario(Guid subComentarioId, Guid usuarioModificacaoId, string comentario)
        {
            SubComentario subComentarioQueSeraEditado = _subComentarios.FirstOrDefault(c => c.Id == subComentarioId);

            new Contract<Comentario>()
                .IsNotNull(subComentarioQueSeraEditado, nameof(subComentarioQueSeraEditado), "O SubComentário informado não existe.")
                .EnsureContractIsValid()
                .AreEquals(subComentarioQueSeraEditado.UsuarioId,
                           usuarioModificacaoId,
                           nameof(usuarioModificacaoId),
                           "O subComentário apenas pode ser editado pelo autor do SubComentário.")
                .EnsureContractIsValid<Comentario, DomainInvalidOperationException>();

            subComentarioQueSeraEditado.Editar(comentario);
        }

        internal void RemoverComentario(Guid subComentarioId, Guid usuarioId)
        {
            SubComentario subComentarioQueSeraRemovido = _subComentarios.FirstOrDefault(c => c.Id == subComentarioId);

            new Contract<Comentario>()
                .IsNotNull(subComentarioQueSeraRemovido, nameof(subComentarioQueSeraRemovido), "O SubComentário informado não existe.")
                .EnsureContractIsValid()
                .AreEquals(subComentarioQueSeraRemovido.UsuarioId,
                           usuarioId,
                           nameof(usuarioId),
                           "O SubComentário apenas pode ser removido pelo autor do comentário.")
                .EnsureContractIsValid<Comentario, DomainInvalidOperationException>();

            _subComentarios.Remove(subComentarioQueSeraRemovido);
        }

        internal int TotalDeComentarios() => _subComentarios.Count;

    }

}
