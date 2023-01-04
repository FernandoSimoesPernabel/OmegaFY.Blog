using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetComment;

public class GetCommentQuery : QueryPagedRequestMediatRBase<PagedResult<GetCommentQueryResult>>
{
}