using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.EF.Repositories.Postagens
{
    public class PostagemRepository : RepositoryCrudBase<Postagem>, IPostagemRepository
    {

        public PostagemRepository(ApplicationContext dbContext) : base(dbContext) { }

        public void PublicarPostagem(Postagem postagem) => Add(postagem);

    }

}
