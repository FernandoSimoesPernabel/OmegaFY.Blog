﻿using MediatR;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Authentication;
using OmegaFY.Blog.Domain.Queries;

namespace OmegaFY.Blog.Application.Queries.Base;

public abstract class QueryHandlerMediatRBase<TQueryHandler, TQueryRequest, TQueryResult> : IRequestHandler<TQueryRequest, TQueryResult>, IQueryHandler<TQueryRequest, TQueryResult>
    where TQueryRequest : IQueryRequest, IRequest<TQueryResult>
    where TQueryResult : IQueryResult
{

    protected readonly IUserInformation _currentUser;

    protected readonly ILogger<TQueryHandler> _logger;

    public QueryHandlerMediatRBase(IUserInformation user, ILogger<TQueryHandler> logger)
    {
        _currentUser = user;
        _logger = logger;
    }

    public async Task<TQueryResult> Handle(TQueryRequest request, CancellationToken cancellationToken) => await HandleAsync(request, cancellationToken);

    public abstract Task<TQueryResult> HandleAsync(TQueryRequest request, CancellationToken cancellationToken);

}