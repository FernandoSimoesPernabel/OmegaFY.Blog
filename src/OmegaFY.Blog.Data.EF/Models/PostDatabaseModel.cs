using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.Models;

public class PostDatabaseModel
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public bool Hidden { get; set; }

    public decimal AverageRate { get; set; }

    public ICollection<AvaliationDatabaseModel> Avaliations { get; set; }

    public ICollection<CommentDatabaseModel> Comments { get; set; }

    public ICollection<SharedDatabaseModel> Shareds { get; set; }
}