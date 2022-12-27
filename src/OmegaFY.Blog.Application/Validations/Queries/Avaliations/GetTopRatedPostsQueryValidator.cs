using FluentValidation;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;

namespace OmegaFY.Blog.Application.Validations.Queries.Posts;

public class GetTopRatedPostsQueryValidator : AbstractValidator<GetTopRatedPostsQuery>
{
    public GetTopRatedPostsQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);

        RuleFor(x => x.PageSize).InclusiveBetween(5, 50);
    }
}