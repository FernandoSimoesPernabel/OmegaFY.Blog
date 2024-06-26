﻿using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;

public sealed record class GetReactionsFromCommentQueryResult : GenericResult, IQueryResult
{
    public ReactionFromPost[] ReactionsFromPost { get; set; }

    public GetReactionsFromCommentQueryResult() { }

    public GetReactionsFromCommentQueryResult(ReactionFromPost[] reactionsFromPost)
    {
        ReactionsFromPost = reactionsFromPost;
    }
}