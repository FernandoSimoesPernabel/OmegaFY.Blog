using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes.DTOs
{

    public class PostagensRecentesDTO
    {

        public Guid Id { get; set; }

        public string Usuario { get; set; }

        public string Titulo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public PostagensRecentesDTO()
        {

        }

        public PostagensRecentesDTO(Guid id, string usuario, string titulo, DateTime dataCriacao, DateTime? dataModificacao)
        {
            Id = id;
            Usuario = usuario;
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataModificacao = dataModificacao;
        }

    }

}
