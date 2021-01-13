using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Comentarios.Base
{

    public abstract class ComentarioBase : Entity
    {

        protected readonly List<Reacao> _reacoes;

        public Guid PostagemId { get; }

        public Guid UsuarioId { get; }

        public DetalhesModificacao DetalhesModificacao { get; protected set; }

        public Corpo Corpo { get; protected set; }

        public IReadOnlyCollection<Reacao> Reacoes => _reacoes.AsReadOnly();

        protected ComentarioBase() { }

        public ComentarioBase(Guid usuarioId, Guid postagemId)
        {
            _reacoes = new List<Reacao>();

            PostagemId = postagemId;
            UsuarioId = usuarioId;
        }

        internal void Editar(string comentario)
        {
            new Contract().ValidarComentario(comentario).EnsureContractIsValid();

            Corpo = comentario;
            DetalhesModificacao = new DetalhesModificacao(DetalhesModificacao.DataCriacao);
        }

        internal void Reagir(Reacao reacao)
        {
            new Contract()
                .IsNotNull(reacao, nameof(reacao), "Não foi informado nenhuma reação para esse comentário.")
                .EnsureContractIsValid();

            _reacoes.Add(reacao);
        }

        internal void RemoverReacao(Guid reacaoId, Guid usuarioId)
        {
            Reacao reacaoQueSeraRemovida = _reacoes.FirstOrDefault(c => c.Id == reacaoId);

            new Contract()
                .IsNotNull(reacaoQueSeraRemovida, nameof(reacaoQueSeraRemovida), "A reação informada não existe.")
                .EnsureContractIsValid()
                .AreEquals(reacaoQueSeraRemovida.UsuarioId,
                           usuarioId,
                           nameof(usuarioId),
                           "O reação apenas pode ser removida pelo usuário que o realizou.")
                .EnsureContractIsValid<DomainInvalidOperationException>();

            _reacoes.Remove(reacaoQueSeraRemovida);
        }

        internal int TotalDeReacoes() => _reacoes.Count;

        internal IDictionary<Reacoes, int> QuantidadeDeReacoesPorReacao() => Reacoes.QuantidadeDeReacoesPorReacao();

        public override string ToString() => Corpo.ToString();

    }

}
