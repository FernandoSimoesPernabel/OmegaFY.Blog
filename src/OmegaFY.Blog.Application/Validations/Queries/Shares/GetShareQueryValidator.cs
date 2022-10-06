using FluentValidation;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Validations.Queries.Shares;

public class GetShareQueryValidator : AbstractValidator<GetShareQuery>
{
    public GetShareQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.ShareId).NotEmpty();
    }
}