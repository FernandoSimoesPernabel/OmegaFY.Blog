using FluentValidation;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

namespace OmegaFY.Blog.Application.Validations.Queries.Posts;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator()
    {
        RuleFor(x => x.AuthorId).NotEmpty().Unless(x => x.AuthorId is null);

        RuleFor(x => x.StartDateOfCreation)
            .NotEmpty()
            .Unless(x => x.StartDateOfCreation is null && x.EndDateOfCreation is null);

        RuleFor(x => x.StartDateOfCreation)
            .LessThanOrEqualTo(x => x.EndDateOfCreation)
            .Unless(x => x.EndDateOfCreation is null);

        RuleFor(x => x.EndDateOfCreation)
            .NotEmpty()
            .Unless(x => x.StartDateOfCreation is null && x.EndDateOfCreation is null);

        RuleFor(x => x.EndDateOfCreation)
            .GreaterThanOrEqualTo(x => x.EndDateOfCreation)
            .Unless(x => x.StartDateOfCreation is null);

        RuleFor(x => x.PageNumber).GreaterThan(0);

        RuleFor(x => x.PageSize).InclusiveBetween(5, 50);
    }
}