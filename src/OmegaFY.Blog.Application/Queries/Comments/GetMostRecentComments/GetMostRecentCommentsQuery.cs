﻿using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;

public sealed record class GetMostRecentCommentsQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentCommentsQueryResult>>
{
    public Guid? AuthorId { get; set; }
}