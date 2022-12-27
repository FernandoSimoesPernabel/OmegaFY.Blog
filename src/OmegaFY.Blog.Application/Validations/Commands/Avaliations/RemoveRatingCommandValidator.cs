using FluentValidation;
using OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;

namespace OmegaFY.Blog.Application.Validations.Commands.Avaliations;

public class RemoveRatingCommandValidator : AbstractValidator<RemoveRatingCommand>
{
    public RemoveRatingCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.AvaliationId).NotEmpty();
    }
}