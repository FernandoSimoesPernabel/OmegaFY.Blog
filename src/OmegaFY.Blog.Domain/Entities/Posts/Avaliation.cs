using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Avaliation : Entity
{
    public Guid PostId { get; }

    public Author Author { get; }

    public Stars Grade { get; private set; }

    public Avaliation(Guid postId, Author author, Stars grade)
    {
        PostId = postId;
        Author = author;
        Grade = grade;
    }

    public void ChangeAuthorAvaliation(Stars newGrade) => Grade = newGrade;
}