﻿using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;

public sealed record class GetMostReactedCommentsQueryResult : GenericResult, IQueryResult
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public Guid CommentAuthorId { get; set; }

    public string CommentAuthorName { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public bool HasCommentBeenEdit { get; set; }

    public int ReactionCount { get; set; }
}