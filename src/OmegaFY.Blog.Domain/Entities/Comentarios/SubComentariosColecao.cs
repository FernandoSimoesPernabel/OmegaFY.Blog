namespace OmegaFY.Blog.Domain.Entities.Comentarios
{
    public class SubComentariosColecao : AbstractEntityCollection<SubComentario>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado um comentário para ser removido.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "O comentário informado não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "O comentário apenas pode ser removido pelo usuário que o comentou.";

        public void Comentar(SubComentario subComentario) => Add(subComentario);

        public void RemoverComentario(SubComentario subComentario) => Remove(subComentario);

    }

}
