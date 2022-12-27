using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;

internal class GetAvaliationQueryHandler : QueryHandlerMediatRBase<GetAvaliationQueryHandler, GetAvaliationQuery, GetAvaliationQueryResult>
{
    private readonly IAvaliationQueryProvider _avaliationQueryProvider;

    public GetAvaliationQueryHandler(IUserInformation currentUser, ILogger<GetAvaliationQueryHandler> logger, IAvaliationQueryProvider avaliationQueryProvider)
        : base(currentUser, logger) => _avaliationQueryProvider = avaliationQueryProvider;

    public async override Task<GetAvaliationQueryResult> HandleAsync(GetAvaliationQuery request, CancellationToken cancellationToken)
    {
        GetAvaliationQueryResult result = await _avaliationQueryProvider.GetAvaliationQueryResultAsync(request, cancellationToken);
        return result ?? throw new NotFoundException();
    }
}