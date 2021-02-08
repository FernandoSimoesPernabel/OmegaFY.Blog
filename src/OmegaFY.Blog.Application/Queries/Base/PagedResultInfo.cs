using System;

namespace OmegaFY.Blog.Application.Queries.Base
{

    public class PagedResultInfo
    {

        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalOfItens { get; private set; }

        public bool HasPrevius => CurrentPage < TotalPages;

        public bool HasNext => CurrentPage > 1;

        public PagedResultInfo(PagedRequest pagedRequest, int totalOfItens) : this(pagedRequest.PageNumber, pagedRequest.PageSize, totalOfItens) { }

        public PagedResultInfo(int currentPage, int pageSize, int totalOfItens)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalOfItens = totalOfItens;
            TotalPages = (int)Math.Ceiling(pageSize / (double)totalOfItens);
        }

    }

}
