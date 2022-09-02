using OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class ChangePostContentInputModel
{
    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public ChangePostContentCommand ToCommand(Guid id) => new ChangePostContentCommand(id, Title, SubTitle, Body);
}