namespace OmegaFY.Blog.Application.Queries.Base.Pagination;

public record class PagedResultInfo
{
    public int CurrentPage { get; }

    public int PageSize { get; }

    public int TotalPages { get; }

    public long TotalOfItems { get; }

    public bool HasPrevious => TotalPages > 0 && CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;

    public PagedResultInfo(PagedRequest pagedRequest, long totalOfItems) : this(pagedRequest.PageNumber, pagedRequest.PageSize, totalOfItems) { }

    public PagedResultInfo(int currentPage, int pageSize, long totalOfItems)
    {
        CurrentPage = Math.Max(currentPage, 1);
        PageSize = Math.Max(pageSize, 1);
        TotalOfItems = totalOfItems;
        TotalPages = (int)Math.Ceiling((double)totalOfItems / pageSize);
    }

    public int ItemsToSkip() => Math.Max(PageSize * (CurrentPage - 1), 0);
}