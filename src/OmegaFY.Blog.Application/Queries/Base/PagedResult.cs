using OmegaFY.Blog.Application.Base;

namespace OmegaFY.Blog.Application.Queries.Base
{

    public abstract class PagedResult : GenericResult
    {

        private readonly PagedResultInfo _resultInfo;

        protected PagedResult() { }

        public PagedResult(PagedResultInfo resultInfo) => _resultInfo = resultInfo;

        public PagedResultInfo ObterDadosPaginacao() => _resultInfo;

    }

}
