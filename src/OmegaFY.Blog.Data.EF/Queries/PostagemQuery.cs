using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Queries.Base;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.Queries
{

    internal class PostagemQuery : ReportingQueryBase<Postagem>, IPostagemQuery
    {

        public PostagemQuery(ApplicationContext dbContext, IMapperServices mapper) : base(dbContext, mapper) { }

        public async Task<ObterPostagemQueryResult> ObterPostagemAsync(ObterPostagemQuery query)
        {
            Postagem postagem =
                await _dbSet
                .AsNoTracking()
                .Include(p => p.Avaliacoes)
                .Include(p => p.Comentarios)
                .Include(p => p.Compartilhamentos)
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            return postagem == null ? null : _mapper.MapToObject<Postagem, ObterPostagemQueryResult>(postagem);
        }

    }

}
