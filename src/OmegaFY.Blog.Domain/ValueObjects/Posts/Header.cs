using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public readonly record struct Header
{
    public string Title { get; }

    public string SubTitle { get; }

    public Header(string title, string subTitle)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > PostConstants.MAX_TITLE_LENGTH)
            throw new DomainArgumentException($"O título do cabeçalho precisa ser informato com até {PostConstants.MAX_TITLE_LENGTH} caracteres.");

        if (string.IsNullOrWhiteSpace(subTitle) || subTitle.Length > PostConstants.MAX_SUBTITLE_LENGTH)
            throw new DomainArgumentException($"O subtítulo do cabeçalho precisa ser informato com até {PostConstants.MAX_SUBTITLE_LENGTH} caracteres.");

        Title = title;
        SubTitle = subTitle;
    }
}