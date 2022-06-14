using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Data.EF.Models;

public class AvaliationDatabaseModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public Stars Rate { get; set; }
}