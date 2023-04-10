namespace OmegaFY.Blog.Application.Queries.Base.Pagination;

public record class PagedRequest
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;

    public PagedRequest() { }

    public PagedRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}