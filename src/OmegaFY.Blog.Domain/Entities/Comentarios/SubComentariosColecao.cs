using System;
using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Comentarios
{
    public class SubComentariosColecao : AbstractEntityCollection<SubComentario>
    {

        protected override string CriticaEntidadeInformadaNula()
            => "Não foi informado um comentário para ser removido.";

        protected override string CriticaEntidadeNaoEncontradaNaColecao()
            => "O comentário informado não existe.";

        protected override string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "O comentário apenas pode ser removido pelo autor do comentário.";

        internal void Comentar(SubComentario subComentario) => Add(subComentario);

        internal void RemoverComentario(SubComentario subComentario) => Remove(subComentario);

        internal void EditarSubComentario(Guid subComentarioId, Guid usuarioModificacaoId, string comentario)
        {
            SubComentario subComentarioQueSeraEditado = _collection.FirstOrDefault(c => c.Id == subComentarioId);

            CriticarOperacaoNaoRealizadaPeloUsuarioOriginal(subComentarioQueSeraEditado,
                                                            usuarioModificacaoId,
                                                            "O comentário apenas pode ser editado pelo autor do comentário.");

            subComentarioQueSeraEditado.Editar(comentario);
        }

    }

}
