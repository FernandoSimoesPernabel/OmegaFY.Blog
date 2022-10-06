using FluentValidation;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;

namespace OmegaFY.Blog.Application.Validations.Queries.Shares;

public class CurrentUserHasSharedPostQueryValidator : AbstractValidator<CurrentUserHasSharedPostQuery>
{
    public CurrentUserHasSharedPostQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}