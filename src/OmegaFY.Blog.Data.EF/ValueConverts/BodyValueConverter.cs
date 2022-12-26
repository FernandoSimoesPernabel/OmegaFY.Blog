using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Data.EF.ValueConverts;

internal class BodyValueConverter : ValueConverter<Body, string>
{
    public BodyValueConverter() : base(x => x.Content, x => new Body(x))
    {
    }
}