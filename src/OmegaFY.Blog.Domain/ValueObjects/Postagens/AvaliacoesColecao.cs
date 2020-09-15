using OmegaFY.Blog.Domain.Entities.Postagens;
using System.Linq;

namespace OmegaFY.Blog.Domain.ValueObjects.Postagens
{

    public class AvaliacoesColecao : AbstractEntityCollection<Avaliacao>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado uma avaliação para ser removida.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "A avaliação informada não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "A avaliação apenas pode ser removida pelo usuário que a realizou.";

        public void Avaliar(Avaliacao avaliacaoAtual)
        {
            Avaliacao avaliacaoJaExistente =
                ReadOnlyCollection.SingleOrDefault(avaliacaoUsuario => avaliacaoUsuario.UsuarioId == avaliacaoAtual?.UsuarioId);

            if (avaliacaoJaExistente != null)
                RemoverAvaliacao(avaliacaoJaExistente);

            Add(avaliacaoAtual);
        }

        public void RemoverAvaliacao(Avaliacao avaliacao) => Remove(avaliacao);

    }

}
