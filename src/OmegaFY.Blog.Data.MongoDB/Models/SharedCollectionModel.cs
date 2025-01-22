using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class SharedCollectionModel
{
    public ReferenceId Id { get; set; }

    public ReferenceId PostId { get; set; }

    public ReferenceId AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}