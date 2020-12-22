using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results;
using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem
{

    public class ObterPostagemQuery : QueryRequestMediatRBase<ObterPostagemQueryResult>
    {

        public Guid Id { get; set; }

    }

}
