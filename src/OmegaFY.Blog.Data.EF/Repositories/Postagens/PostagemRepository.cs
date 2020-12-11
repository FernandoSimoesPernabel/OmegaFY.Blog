using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.Repositories.Postagens
{
    internal class PostagemRepository : RepositoryCrudBase<Postagem>, IPostagemRepository
    {

        public PostagemRepository(ApplicationContext dbContext) : base(dbContext) { }

        public async Task PublicarPostagem(Postagem postagem) => await AddAsync(postagem);

    }

}
