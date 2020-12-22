using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results;
using OmegaFY.Blog.Data.EF.Base;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.Queries
{

    internal class PostagemQuery : RepositoryCrudBase<Postagem>, IPostagemQuery
    {

        protected readonly IMapperServices _mapper;

        public PostagemQuery(ApplicationContext dbContext, IMapperServices mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<ObterPostagemQueryResult> ObterPostagemAsync(ObterPostagemQuery query)
        {
            Postagem postagem = await Get(query.Id, p => p.Comentarios, p => p.Avaliacoes, p => p.Compartilhamentos);
            return postagem == null ? null : _mapper.MapToObject<Postagem, ObterPostagemQueryResult>(postagem);
        }

    }

}
