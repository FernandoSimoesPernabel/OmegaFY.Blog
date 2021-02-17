using Flunt.Validations;
using OmegaFY.Blog.Common.Constantes;
using System;

namespace OmegaFY.Blog.Domain.Extensions
{

    public static class FluntDomainExtensions
    {
        public static Contract<T> ValidarUsuarioId<T>(this Contract<T> contract, Guid usuarioId)
            => contract.ValidarGuidVazio(usuarioId, nameof(usuarioId), "Não foi informado um identificador de usuário válido.");

        public static Contract<T> ValidarPostagemId<T>(this Contract<T> contract, Guid postagemId)
            => contract.ValidarGuidVazio(postagemId, nameof(postagemId), "Não foi informado um identificador de postagem válida.");

        public static Contract<T> ValidarComentarioId<T>(this Contract<T> contract, Guid comentarioId)
            => contract.ValidarGuidVazio(comentarioId, nameof(comentarioId), "Não foi informado um identificador de comentário válido.");

        public static Contract<T> ValidarSubComentarioId<T>(this Contract<T> contract, Guid comentarioId)
            => contract.ValidarGuidVazio(comentarioId, nameof(comentarioId), "Não foi informado um identificador de SubComentário válido.");

        public static Contract<T> ValidarGuidVazio<T>(this Contract<T> contract, Guid usuarioId, string property, string message)
            => contract.IsNotEmpty(usuarioId, property, message);

        public static Contract<T> ValidarComentario<T>(this Contract<T> contract, string comentario)
            => contract.IsBetweenLength(comentario,
                                        ComentariosConstantes.TAMANHO_MIN_COMENTARIO,
                                        ComentariosConstantes.TAMANHO_MAX_COMENTARIO,
                                        nameof(comentario),
                                        $"Um comentário precisa conter entre {ComentariosConstantes.TAMANHO_MIN_COMENTARIO} e {ComentariosConstantes.TAMANHO_MAX_COMENTARIO} caracteres.");

        public static Contract<T> ValidarTitulo<T>(this Contract<T> contract, string titulo)
            => contract.IsBetweenLength(titulo,
                                        PostagensConstantes.TAMANHO_MIN_TITULO,
                                        PostagensConstantes.TAMANHO_MAX_TITULO,
                                        nameof(titulo),
                                        $"Um título precisa conter entre {PostagensConstantes.TAMANHO_MIN_TITULO} e {PostagensConstantes.TAMANHO_MAX_TITULO} caracteres.");

        public static Contract<T> ValidarSubTitulo<T>(this Contract<T> contract, string subTitulo)
            => contract.IsBetweenLength(subTitulo,
                                        PostagensConstantes.TAMANHO_MIN_SUB_TITULO,
                                        PostagensConstantes.TAMANHO_MAX_SUB_TITULO,
                                        nameof(subTitulo),
                                        $"Um subtítulo precisa conter entre {PostagensConstantes.TAMANHO_MIN_SUB_TITULO} e {PostagensConstantes.TAMANHO_MAX_SUB_TITULO} caracteres.");

    }

}
