using FluentValidation;
using OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;

namespace OmegaFY.Blog.Application.Validations.Queries.Comments;

public class GetCommentsFromPostQueryValidator : AbstractValidator<GetCommentsFromPostQuery>
{
    public GetCommentsFromPostQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}