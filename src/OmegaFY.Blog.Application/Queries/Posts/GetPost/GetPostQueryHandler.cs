using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

internal class GetPostQueryHandler : QueryHandlerMediatRBase<GetPostQueryHandler, GetPostQuery, GetPostQueryResult>
{
    private readonly IPostQueryProvider _postQueryProvider;

    public GetPostQueryHandler(IUserInformation currentUser, ILogger<GetPostQueryHandler> logger, IPostQueryProvider postQueryProvider)
        : base(currentUser, logger) => _postQueryProvider = postQueryProvider;

    public override async Task<GetPostQueryResult> HandleAsync(GetPostQuery request, CancellationToken cancellationToken)
    {
        GetPostQueryResult result = await _postQueryProvider.GetPostQueryResultAsync(request.Id, cancellationToken);
        return result ?? throw new NotFoundException();
    }
}
