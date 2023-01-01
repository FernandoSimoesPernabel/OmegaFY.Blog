using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

public class GetPostQuery : QueryRequestMediatRBase<GetPostQueryResult>
{
    public Guid Id { get; set; }

    public GetPostQuery() { }

    public GetPostQuery(Guid id)
    {
        Id = id;
    }
}
