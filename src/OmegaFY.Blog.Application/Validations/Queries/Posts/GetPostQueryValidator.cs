using FluentValidation;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;

namespace OmegaFY.Blog.Application.Validations.Queries.Posts;

public class GetPostQueryValidator : AbstractValidator<GetPostQuery>
{
    public GetPostQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}