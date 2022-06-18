namespace OmegaFY.Blog.Data.EF.Models;

public class UserDatabaseModel
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string DisplayName { get; set; }

    public ICollection<PostDatabaseModel> Posts { get; set; }

    public ICollection<AvaliationDatabaseModel> Avaliations { get; set; }

    public ICollection<CommentDatabaseModel> Comments { get; set; }

    public ICollection<ReactionDatabaseModel> Reactions { get; set; }

    public ICollection<SharedDatabaseModel> Shareds { get; set; }
}