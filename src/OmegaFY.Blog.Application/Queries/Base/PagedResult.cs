﻿using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Queries;

namespace OmegaFY.Blog.Application.Queries.Base
{

    public abstract class PagedResult : GenericResult, IQueryResult
    {

        private readonly PagedResultInfo _resultInfo;

        protected PagedResult() { }

        public PagedResult(PagedResultInfo resultInfo) => _resultInfo = resultInfo;

        public PagedResultInfo ObterDadosPaginacao() => _resultInfo;

    }

}
