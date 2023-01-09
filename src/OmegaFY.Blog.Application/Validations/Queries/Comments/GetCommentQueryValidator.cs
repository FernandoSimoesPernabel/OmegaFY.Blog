using FluentValidation;
using OmegaFY.Blog.Application.Queries.Comments.GetComment;

namespace OmegaFY.Blog.Application.Validations.Queries.Comments;

public class GetCommentQueryValidator : AbstractValidator<GetCommentQuery>
{
    public GetCommentQueryValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();
    }
}