using FluentValidation;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;

namespace OmegaFY.Blog.Application.Validations.Queries.Avaliations;

public class GetAvaliationsFromPostQueryValidator : AbstractValidator<GetAvaliationsFromPostQuery>
{
    public GetAvaliationsFromPostQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}