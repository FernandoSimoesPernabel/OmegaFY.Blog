using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario.DTOs
{

    public class PostagensDoUsuarioDTO
    {

        public Guid PostagemId { get; set; }

        public string Autor { get; set; }

        public string Titulo { get; set; }

        public DateTime DataPublicacao { get; set; }

        public PostagensDoUsuarioDTO() { }

        public PostagensDoUsuarioDTO(Guid postagemId, string autor, string titulo, DateTime dataPublicacao)
        {
            PostagemId = postagemId;
            Autor = autor;
            Titulo = titulo;
            DataPublicacao = dataPublicacao;
        }

    }

}
