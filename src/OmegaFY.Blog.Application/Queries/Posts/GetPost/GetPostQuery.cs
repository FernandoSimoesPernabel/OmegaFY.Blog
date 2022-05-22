using OmegaFY.Blog.Application.Queries.Base;

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
