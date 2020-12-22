using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Queries;
using System;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results
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

        public IReadOnlyCollection<ObterPostagemAvaliacoesQuery> Avaliacoes { get; set; }

        public IReadOnlyCollection<ObterPostagemComentariosQuery> Comentarios { get; set; }

        public IReadOnlyCollection<ObterPostagemCompartilhamentosQuery> Compartilhamentos { get; set; }

    }

}
