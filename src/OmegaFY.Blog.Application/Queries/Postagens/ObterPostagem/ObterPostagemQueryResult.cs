using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Queries;
using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem
{

    public class ObterPostagemQueryResult : GenericResult, IQueryResult
    {

        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string Corpo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public int TotalDeAvaliacoes { get; set; }

        public int TotalDeComentarios { get; set; }

        public int TotalDeCompartilhamentos { get; set; }

    }

}
