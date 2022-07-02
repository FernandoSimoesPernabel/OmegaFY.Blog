namespace OmegaFY.Blog.Application.Queries.Base.Pagination;

public class PagedRequest
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public PagedRequest() { }

    public PagedRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}