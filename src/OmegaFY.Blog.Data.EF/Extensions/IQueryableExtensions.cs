using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedResultInfo pagedResultInfo)
        => query.Skip(pagedResultInfo.ItemsToSkip()).Take(pagedResultInfo.PageSize);
}