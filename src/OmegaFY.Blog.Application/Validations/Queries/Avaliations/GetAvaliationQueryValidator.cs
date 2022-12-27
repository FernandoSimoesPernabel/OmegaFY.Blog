using FluentValidation;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;

namespace OmegaFY.Blog.Application.Validations.Queries.Avaliations;

public class GetAvaliationQueryValidator : AbstractValidator<GetAvaliationQuery>
{
    public GetAvaliationQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.AvaliationId).NotEmpty();
    }
}