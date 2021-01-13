using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.Repositories
{
    internal class PostagemRepository : RepositoryCrudBase<Postagem>, IPostagemRepository
    {

        public PostagemRepository(ApplicationContext dbContext) : base(dbContext) { }

        public void AtualizarDadosPostagem(Postagem postagem) => Update(postagem);

        public async Task<Postagem> PesquisarPostagemPeloId(Guid id)
        {
            return await _dbSet
                .Include(p => p.Avaliacoes)
                .Include(p => p.Comentarios)
                    .ThenInclude(c => c.SubComentarios)
                .Include(p => p.Compartilhamentos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task PublicarPostagem(Postagem postagem) => await AddAsync(postagem);

    }

}
