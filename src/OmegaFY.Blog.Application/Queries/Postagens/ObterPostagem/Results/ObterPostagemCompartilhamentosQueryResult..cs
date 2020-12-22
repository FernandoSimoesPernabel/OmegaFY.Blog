using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results
{

    public class ObterPostagemCompartilhamentosQuery
    {

        public Guid Id { get; set; }

        public Guid PostagemId { get; set; }

        public DateTime DataCompartilhamento { get; set; }

    }

}
