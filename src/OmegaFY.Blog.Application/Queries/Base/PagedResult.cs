namespace OmegaFY.Blog.Application.Queries.Base
{

    public abstract class PagedResult
    {

        private readonly PagedResultInfo _resultInfo;

        public PagedResult(PagedResultInfo resultInfo) => _resultInfo = resultInfo;

        public PagedResultInfo ObterDadosPaginacao() => _resultInfo;

    }

}
