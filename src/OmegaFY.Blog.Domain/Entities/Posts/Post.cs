using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Post : Entity, IAggregateRoot<Post>
{
    public Author Author { get; }

    public Header Header { get; private set; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public bool Private { get; private set; }

    protected Post() { }

    public Post(Author author, Header header, Body body)
    {
        if (author is null)
            throw new DomainArgumentException("Não foi informado corretamente um autor para esse post.");

        ChangeContent(header, body);
        Author = author;
        Private = false;
        ModificationDetails = new ModificationDetails();
    }

    public void ChangeContent(Header header, Body body)
    {
        if (header is null)
            throw new DomainArgumentException("Não foi informado corretamente um cabeçalho para esse post.");

        if (string.IsNullOrWhiteSpace(body?.Content) || body.Content.Length > PostConstants.MAX_POST_BODY_LENGTH)
            throw new DomainArgumentException("O conteúdo desse post foi informado incorretamente.");

        Header = header;
        Body = body;

        if (ModificationDetails is not null)
            ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }

    public void MakePrivate() => Private = true;

    public void MakePublic() => Private = false;
}