﻿using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;

public sealed record class GetMostRecentAvaliationsQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentAvaliationsQueryResult>>
{
    public Guid? AuthorId { get; set; }
}