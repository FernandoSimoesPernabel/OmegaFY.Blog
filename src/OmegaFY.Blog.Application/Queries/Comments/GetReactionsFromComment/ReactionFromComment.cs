﻿using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;

public sealed record class ReactionFromComment
{
    public Guid ReactionId { get; set; }

    public Guid CommentId { get; set; }

    public Guid ReactionAuthorId { get; set; }

    public string ReactionAuthorName { get; set; }

    public CommentReaction CommentReaction { get; set; }
}