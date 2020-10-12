using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;
using System.Collections.Generic;

namespace OmegaFY.Blog.Domain.Entities.Comentarios.Base
{

    public abstract class ComentarioBase : Entity
    {

        protected readonly ReacoesColecao _reacoes;

        public Guid PostagemId { get; }

        public DetalhesModificacao DetalhesModificacao { get; protected set; }

        public Corpo Corpo { get; protected set; }

        public IReadOnlyCollection<Reacao> Reacoes => _reacoes.ReadOnlyCollection;

        protected ComentarioBase() { }

        public ComentarioBase(Guid usuarioId, Guid postagemId)
        {
            _reacoes = new ReacoesColecao();

            UsuarioId = usuarioId;
            PostagemId = postagemId;
        }

        public void Editar(string comentario)
        {
            new Contract().ValidarComentario(comentario).EnsureContractIsValid();

            Corpo = comentario;
            DetalhesModificacao = new DetalhesModificacao(DetalhesModificacao.DataCriacao);
        }

        public void Reagir(Guid usuarioId, Reacoes reacoes) => _reacoes.Reagir(new Reacao(usuarioId, Id, reacoes));

        public void RemoverReacao(Reacao reacao) => _reacoes.RemoverReacao(reacao);

        public int TotalDeReacoes() => _reacoes.Total();

        public IDictionary<Reacoes, int> QuantidadeDeReacoesPorReacao() => Reacoes.QuantidadeDeReacoesPorReacao();

        public override string ToString() => Corpo.ToString();

    }

}
