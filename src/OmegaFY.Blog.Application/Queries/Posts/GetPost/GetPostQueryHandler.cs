using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Domain.Authentication;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

public class GetPostQueryHandler : QueryHandlerMediatRBase<GetPostQueryHandler, GetPostQuery, GetPostQueryResult>
{
    public GetPostQueryHandler(IUserInformation user, ILogger<GetPostQueryHandler> logger) : base(user, logger)
    {
    }

    public override Task<GetPostQueryResult> HandleAsync(GetPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
