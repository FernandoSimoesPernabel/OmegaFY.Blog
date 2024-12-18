﻿using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;

internal sealed class GetAvaliationsFromPostQueryHandler : QueryHandlerMediatRBase<GetAvaliationsFromPostQueryHandler, GetAvaliationsFromPostQuery, GetAvaliationsFromPostQueryResult>
{
    private readonly IAvaliationQueryProvider _avaliationQueryProvider;

    public GetAvaliationsFromPostQueryHandler(IUserInformation currentUser, ILogger<GetAvaliationsFromPostQueryHandler> logger, IAvaliationQueryProvider avaliationQueryProvider)
        : base(currentUser, logger) => _avaliationQueryProvider = avaliationQueryProvider;

    public override Task<GetAvaliationsFromPostQueryResult> HandleAsync(GetAvaliationsFromPostQuery request, CancellationToken cancellationToken)
        => _avaliationQueryProvider.GetAvaliationsFromPostQueryResultAsync(request, cancellationToken);
}