using FluentValidation;
using OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Validations.Commands.Avaliations;

public class ChangeUserRatingCommandValidator : AbstractValidator<ChangeUserRatingCommand>
{
    public ChangeUserRatingCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();

        RuleFor(x => x.AvaliationId).NotEmpty();

        RuleFor(x => x.NewRate).IsInEnum();
    }
}