using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class AvaliationCollectionModel
{
    public ReferenceId Id { get; set; }

    public ReferenceId PostId { get; set; }

    public ReferenceId AuthorId { get; set; }

    public ModificationDetails ModificationDetails { get; set; }

    public Stars Rate { get; set; }
}