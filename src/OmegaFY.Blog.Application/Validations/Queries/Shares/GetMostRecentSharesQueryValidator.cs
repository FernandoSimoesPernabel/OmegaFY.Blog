using FluentValidation;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.Application.Validations.Queries.Shares;

public class GetMostRecentSharesQueryValidator : AbstractValidator<GetMostRecentSharesQuery>
{
    public GetMostRecentSharesQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);

        RuleFor(x => x.PageSize).InclusiveBetween(5, 50);
    }
}