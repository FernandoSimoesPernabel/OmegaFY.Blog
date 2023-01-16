using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetComment;

public class GetCommentQuery : QueryRequestMediatRBase<GetCommentQueryResult>
{
    public Guid CommentId { get; set; }
}