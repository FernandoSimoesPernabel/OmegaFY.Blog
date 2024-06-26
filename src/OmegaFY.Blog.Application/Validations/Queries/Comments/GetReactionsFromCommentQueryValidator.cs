﻿using FluentValidation;
using OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;

namespace OmegaFY.Blog.Application.Validations.Queries.Comments;

public class GetReactionsFromCommentQueryValidator : AbstractValidator<GetReactionsFromCommentQuery>
{
    public GetReactionsFromCommentQueryValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();
    }
}