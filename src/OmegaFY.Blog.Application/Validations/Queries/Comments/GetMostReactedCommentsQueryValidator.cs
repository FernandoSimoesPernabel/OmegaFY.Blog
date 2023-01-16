using FluentValidation;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;

namespace OmegaFY.Blog.Application.Validations.Queries.Comments;

public class GetMostReactedCommentsQueryValidator : AbstractValidator<GetMostReactedCommentsQuery>
{
    public GetMostReactedCommentsQueryValidator()
    {
        RuleFor(x => x.AuthorId).NotEmpty().Unless(x => x.AuthorId is null);

        RuleFor(x => x.PageNumber).GreaterThan(0);

        RuleFor(x => x.PageSize).InclusiveBetween(5, 50);
    }
}