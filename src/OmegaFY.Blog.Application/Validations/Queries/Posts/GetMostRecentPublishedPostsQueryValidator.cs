using FluentValidation;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Validations.Queries.Posts;

public class GetMostRecentPublishedPostsQueryValidator : AbstractValidator<GetMostRecentPublishedPostsQuery>
{
    public GetMostRecentPublishedPostsQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);

        RuleFor(x => x.PageSize).InclusiveBetween(5, 50);
    }
}