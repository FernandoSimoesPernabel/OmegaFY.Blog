using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class UnsharePostInputModel
{
    public Guid PostId { get; set; }

    public Guid ShareId { get; set; }

    public UnsharePostCommand ToCommand() => new UnsharePostCommand(PostId, ShareId);
}