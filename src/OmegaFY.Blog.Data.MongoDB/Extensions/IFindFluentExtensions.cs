using MongoDB.Driver;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class IFindFluentExtensions
{
    public static IFindFluent<TDocument, TProjection> Paginate<TDocument, TProjection>(this IFindFluent<TDocument, TProjection> query, PagedResultInfo pagedResultInfo)
        => query.Skip(pagedResultInfo.ItemsToSkip()).Limit(pagedResultInfo.PageSize);
}