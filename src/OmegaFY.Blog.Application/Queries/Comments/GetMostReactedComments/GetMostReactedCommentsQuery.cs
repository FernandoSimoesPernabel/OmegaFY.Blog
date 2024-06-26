﻿using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;

public sealed record class GetMostReactedCommentsQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostReactedCommentsQueryResult>>
{
    public Guid? AuthorId { get; set; }
}