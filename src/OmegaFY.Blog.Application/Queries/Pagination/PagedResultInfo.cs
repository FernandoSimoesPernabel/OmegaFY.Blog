﻿namespace OmegaFY.Blog.Application.Queries.Pagination;

public class PagedResultInfo
{
    public int CurrentPage { get; }

    public int PageSize { get; }

    public int TotalPages { get; }

    public int TotalOfItens { get; }

    public bool HasPrevious => CurrentPage < TotalPages;

    public bool HasNext => CurrentPage > 1;

    public PagedResultInfo(PagedRequest pagedRequest, int totalOfItens) : this(pagedRequest.PageNumber, pagedRequest.PageSize, totalOfItens) { }

    public PagedResultInfo(int currentPage, int pageSize, int totalOfItens)
    {
        CurrentPage = currentPage;
        PageSize = Math.Max(pageSize, 1);
        TotalOfItens = totalOfItens;
        TotalPages = (int)Math.Ceiling((double)totalOfItens / pageSize);
    }

    public int ItemsToSkip() => Math.Max(PageSize * (CurrentPage - 1), 0);
}