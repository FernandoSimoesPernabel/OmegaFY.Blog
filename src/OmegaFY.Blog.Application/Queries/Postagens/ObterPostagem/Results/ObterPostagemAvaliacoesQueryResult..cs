using OmegaFY.Blog.Common.Enums;
using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results
{
    public class ObterPostagemAvaliacoesQuery
    {

        public Guid Id { get; }

        public Guid PostagemId { get; }

        public DateTime DataAvaliacao { get; }

        public float Nota { get; }

        public Estrelas Estrelas { get; }

    }

}
