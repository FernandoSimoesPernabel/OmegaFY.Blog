using OmegaFY.Blog.Domain.Core.Enums;
using OmegaFY.Blog.Domain.Entities.Comentarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.Domain.Extensions
{

    public static class ReacaoExtensions
    {

        public static IDictionary<Reacoes, int> QuantidadeDeReacoesPorReacao(this IReadOnlyCollection<Reacao> reacoes)
        {
            string[] tiposDeReacao = Enum.GetNames(typeof(Reacoes));

            Dictionary<Reacoes, int> reacoesComQuantidade = new Dictionary<Reacoes, int>(tiposDeReacao.Length);

            foreach (string reacao in tiposDeReacao)
                reacoesComQuantidade.Add(Enum.Parse<Reacoes>(reacao), reacoes.Count(r => r.ReacaoUsuario.ToString() == reacao));

            return reacoesComQuantidade;
        }

    }

}
