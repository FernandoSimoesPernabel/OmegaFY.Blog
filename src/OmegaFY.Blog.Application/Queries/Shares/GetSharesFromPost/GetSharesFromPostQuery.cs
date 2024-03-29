﻿using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Shares.GetSharesFromPost;

public class GetSharesFromPostQuery : QueryRequestMediatRBase<GetSharesFromPostQueryResult>
{
    public Guid PostId { get; set; }
}