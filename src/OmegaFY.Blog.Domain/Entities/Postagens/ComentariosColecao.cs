using OmegaFY.Blog.Domain.Entities.Comentarios;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class ComentariosColecao : AbstractEntityCollection<Comentario>
    {

        protected override string CriticaEntidadeInformadaNula() 
            => "Não foi informado um comentário para ser removido.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao() 
            => "O comentário informado não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal() 
            => "O comentário apenas pode ser removido pelo usuário que o comentou.";

        public void Comentar(Comentario comentario) => Add(comentario);

        public void RemoverComentario(Comentario comentario) => Remove(comentario);

    }

}
