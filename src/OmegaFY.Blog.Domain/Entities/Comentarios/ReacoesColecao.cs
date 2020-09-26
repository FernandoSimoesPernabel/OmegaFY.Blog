using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{

    public class ReacoesColecao : AbstractEntityCollection<Reacao>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado um comentário para ser removido.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "O comentário informado não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "O comentário apenas pode ser removido pelo usuário que o comentou.";

        public void Reagir(Reacao reacaoAtual)
        {
            Reacao reacaoJaExistente =
                ReadOnlyCollection.SingleOrDefault(reacaoUsuario => reacaoUsuario.UsuarioId == reacaoAtual?.UsuarioId);

            if (reacaoJaExistente != null)
                RemoverReacao(reacaoJaExistente);

            Add(reacaoAtual);
        }

        public void RemoverReacao(Reacao reacao) => Remove(reacao);

    }

}
