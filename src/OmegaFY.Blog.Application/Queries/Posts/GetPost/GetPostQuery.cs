using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

public class GetPostQuery : QueryRequestMediatRBase<GetPostQueryResult>
{
    public Guid PostId { get; set; }

    public GetPostQuery() { }

    public GetPostQuery(Guid postId)
    {
        PostId = postId;
    }
}
