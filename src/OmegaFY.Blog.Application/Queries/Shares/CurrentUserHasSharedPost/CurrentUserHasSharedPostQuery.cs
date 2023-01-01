using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;

public class CurrentUserHasSharedPostQuery : QueryRequestMediatRBase<CurrentUserHasSharedPostQueryResult>
{
    public Guid Id { get; set; }

    public CurrentUserHasSharedPostQuery() { }

    public CurrentUserHasSharedPostQuery(Guid id)
    {
        Id = id;
    }
}