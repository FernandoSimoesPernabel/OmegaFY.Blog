using Flunt.Validations;
using OmegaFY.Blog.Domain.Core.Constantes;
using System;

namespace OmegaFY.Blog.Domain.Extensions
{

    public static class FluntDomainExtensions
    {
        public static Contract ValidarUsuarioId(this Contract contract, Guid usuarioId)
            => contract.ValidarGuidVazio(usuarioId, nameof(usuarioId), "Não foi informado um usuário válido.");

        public static Contract ValidarPostagemId(this Contract contract, Guid postagemId)
            => contract.ValidarGuidVazio(postagemId, nameof(postagemId), "Não foi informado uma postagem válida.");

        public static Contract ValidarComentarioId(this Contract contract, Guid comentarioId)
            => contract.ValidarGuidVazio(comentarioId, nameof(comentarioId), "Não foi informado um comentário válido.");

        public static Contract ValidarGuidVazio(this Contract contract, Guid usuarioId, string property, string message)
            => contract.IsNotEmpty(usuarioId, property, message);

        public static Contract ValidarComentario(this Contract contract, string comentario)
            => contract.IsBetween(comentario,
                                  ComentariosConstantes.TAMANHO_MIN_COMENTARIO,
                                  ComentariosConstantes.TAMANHO_MAX_COMENTARIO,
                                  nameof(comentario),
                                  $"Um comentário precisa conter entre {ComentariosConstantes.TAMANHO_MIN_COMENTARIO} e {ComentariosConstantes.TAMANHO_MAX_COMENTARIO} caracteres.");

        public static Contract ValidarTitulo(this Contract contract, string titulo)
            => contract.IsBetween(titulo,
                                  PostagensConstantes.TAMANHO_MIN_TITULO,
                                  PostagensConstantes.TAMANHO_MAX_TITULO,
                                  nameof(titulo),
                                  $"Um título precisa conter entre {PostagensConstantes.TAMANHO_MIN_TITULO} e {PostagensConstantes.TAMANHO_MAX_TITULO} caracteres.");

        public static Contract ValidarSubTitulo(this Contract contract, string subTitulo)
            => contract.IsBetween(subTitulo,
                                  PostagensConstantes.TAMANHO_MIN_SUB_TITULO,
                                  PostagensConstantes.TAMANHO_MAX_SUB_TITULO,
                                  nameof(subTitulo),
                                  $"Um subtítulo precisa conter entre {PostagensConstantes.TAMANHO_MIN_SUB_TITULO} e {PostagensConstantes.TAMANHO_MAX_SUB_TITULO} caracteres.");

    }

}
