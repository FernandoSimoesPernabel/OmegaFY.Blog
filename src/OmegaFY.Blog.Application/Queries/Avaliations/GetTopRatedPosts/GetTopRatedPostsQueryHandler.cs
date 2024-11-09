using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;

internal sealed class GetTopRatedPostsQueryHandler : QueryHandlerMediatRBase<GetTopRatedPostsQueryHandler, GetTopRatedPostsQuery, PagedResult<GetTopRatedPostsQueryResult>>
{
    private readonly IAvaliationQueryProvider _avaliationQueryProvider;

    public GetTopRatedPostsQueryHandler(IUserInformation currentUser, ILogger<GetTopRatedPostsQueryHandler> logger, IAvaliationQueryProvider avaliationQueryProvider)
        : base(currentUser, logger) => _avaliationQueryProvider = avaliationQueryProvider;

    public override Task<PagedResult<GetTopRatedPostsQueryResult>> HandleAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken)
        => _avaliationQueryProvider.GetTopRatedPostsQueryResultAsync(request, cancellationToken);
}
