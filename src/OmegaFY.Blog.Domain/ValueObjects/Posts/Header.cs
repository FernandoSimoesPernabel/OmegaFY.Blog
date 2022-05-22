namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Header
{
    public string Title { get; }

    public string SubTitle { get; }

    public Header(string title, string subTitle)
    {
        Title = title;
        SubTitle = subTitle;
    }
}
