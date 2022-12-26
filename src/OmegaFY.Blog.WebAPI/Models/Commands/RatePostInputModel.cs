using OmegaFY.Blog.Application.Commands.Avaliations.RatePost;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class RatePostInputModel
{
    public Guid PostId { get; set; }

    public Stars Rate { get; set; }

    public RatePostCommand ToCommand() => new RatePostCommand(PostId, Rate);
}