using FluentValidation;
using OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;

namespace OmegaFY.Blog.Application.Validations.Queries.Posts;

public class GetMostRecentAvaliationsQueryValidator : AbstractValidator<GetMostRecentAvaliationsQuery>
{
    public GetMostRecentAvaliationsQueryValidator()
    {
        RuleFor(x => x.AuthorId).NotEmpty();

        RuleFor(x => x.PageNumber).GreaterThan(0);

        RuleFor(x => x.PageSize).InclusiveBetween(5, 50);
    }
}