namespace OmegaFY.Blog.Data.EF.Models;

public class UserDatabaseModel
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string DisplayName { get; set; }
}