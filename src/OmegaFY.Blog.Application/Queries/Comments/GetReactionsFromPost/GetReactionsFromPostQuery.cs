using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

public class GetReactionsFromPostQuery : QueryPagedRequestMediatRBase<PagedResult<GetReactionsFromPostQueryResult>>
{
}