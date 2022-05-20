using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Domain.Authentication;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.QueryProviders.Posts;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

public class GetPostQueryHandler : QueryHandlerMediatRBase<GetPostQueryHandler, GetPostQuery, GetPostQueryResult>
{
    private readonly IPostQueryProvider _postQueryProvider;

    public GetPostQueryHandler(IUserInformation user, ILogger<GetPostQueryHandler> logger, IPostQueryProvider postQueryProvider) : base(user, logger)
    {
        _postQueryProvider = postQueryProvider;
    }

    public override async Task<GetPostQueryResult> HandleAsync(GetPostQuery request, CancellationToken cancellationToken)
    {
        GetPostQueryResult result = await _postQueryProvider.GetPostQueryResultAsync(request.PostId, cancellationToken);

        if (result is null) throw new NotFoundException();

        return result;
    }
}
