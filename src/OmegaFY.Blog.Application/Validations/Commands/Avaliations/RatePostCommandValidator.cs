using FluentValidation;
using OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

namespace OmegaFY.Blog.Application.Validations.Commands.Avaliations;

public class RatePostCommandValidator : AbstractValidator<RatePostCommand>
{
    public RatePostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.Rate).IsInEnum();
    }
}