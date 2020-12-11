using OmegaFY.Blog.Domain.Entities.Comentarios;
using System;
using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class ComentariosColecao : AbstractEntityCollection<Comentario>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado um comentário para ser removido.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "O comentário informado não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "O comentário apenas pode ser removido pelo autor do comentário.";

        internal void Comentar(Comentario comentario) => Add(comentario);

        internal void RemoverComentario(Comentario comentario) => Remove(comentario);

        internal void EditarComentario(Guid comentarioId, Guid usuarioModificacaoId, string comentario)
        {
            Comentario comentarioQueSeraEditado = _collection.FirstOrDefault(c => c.Id == comentarioId);

            CriticarOperacaoNaoRealizadaPeloUsuarioOriginal(comentarioQueSeraEditado,
                                                            usuarioModificacaoId,
                                                            "O comentário apenas pode ser editado pelo autor do comentário.");

            comentarioQueSeraEditado.Editar(comentario);
        }

    }

}
