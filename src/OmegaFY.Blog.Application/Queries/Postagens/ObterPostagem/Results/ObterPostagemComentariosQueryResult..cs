using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results
{

    public class ObterPostagemComentariosQuery
    {

        public Guid Id { get; set; }

        public Guid PostagemId { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public string Corpo { get; set; }

    }

}
