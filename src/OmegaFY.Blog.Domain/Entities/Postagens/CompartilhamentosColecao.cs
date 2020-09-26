namespace OmegaFY.Blog.Domain.Entities.Postagens
{
    public class CompartilhamentosColecao : AbstractEntityCollection<Compartilhamento>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado um compartilhamento para ser removido.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "O compartilhamento informado não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "O compartilhamento apenas pode ser descompartilhado pelo usuário que o realizou.";

        public void Compartilhar(Compartilhamento compartilhamento) => Add(compartilhamento);

        public void Descompartilhar(Compartilhamento compartilhamento) => Remove(compartilhamento);

    }

}
