﻿using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;

internal sealed class GetMostRecentPublishedPostsQueryHandler : QueryHandlerMediatRBase<GetMostRecentPublishedPostsQueryHandler, GetMostRecentPublishedPostsQuery, PagedResult<GetMostRecentPublishedPostsQueryResult>>
{
    private readonly IPostQueryProvider _postQueryProvider;

    public GetMostRecentPublishedPostsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentPublishedPostsQueryHandler> logger, IPostQueryProvider postQueryProvider) : base(currentUser, logger) 
        => _postQueryProvider = postQueryProvider;

    public override Task<PagedResult<GetMostRecentPublishedPostsQueryResult>> HandleAsync(GetMostRecentPublishedPostsQuery request, CancellationToken cancellationToken) 
        => _postQueryProvider.GetMostRecentPublishedPostsQueryResultAsync(request, cancellationToken);
}