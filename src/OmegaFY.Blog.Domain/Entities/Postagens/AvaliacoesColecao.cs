using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class AvaliacoesColecao : AbstractEntityCollection<Avaliacao>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado uma avaliação para ser removida.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "A avaliação informada não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "A avaliação apenas pode ser removida pelo usuário que a realizou.";

        internal void Avaliar(Avaliacao avaliacaoAtual)
        {
            Avaliacao avaliacaoJaExistente =
                ReadOnlyCollection.SingleOrDefault(avaliacaoUsuario => avaliacaoUsuario.UsuarioId == avaliacaoAtual?.UsuarioId);

            if (avaliacaoJaExistente != null)
                RemoverAvaliacao(avaliacaoJaExistente);

            Add(avaliacaoAtual);
        }

        internal void RemoverAvaliacao(Avaliacao avaliacao) => Remove(avaliacao);

    }

}
