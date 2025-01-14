using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Post : Entity, IAggregateRoot<Post>
{
    public ReferenceId AuthorId { get; }

    public Header Header { get; private set; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public bool Private { get; private set; }

    protected Post() { }

    public Post(ReferenceId postId, ReferenceId authorId, Header header, Body body, ModificationDetails modificationDetails, bool isPrivate) : base(postId)
    {
        AuthorId = authorId;
        Header = header;
        Body = body;
        ModificationDetails = modificationDetails;
        Private = isPrivate;
    }

    public Post(ReferenceId authorId, Header header, Body body)
    {
        AuthorId = authorId;
        Private = false;
        ChangeContent(header, body);
        ModificationDetails = new ModificationDetails();
    }

    public void ChangeContent(Header header, Body body)
    {
        if (body.Content.Length > PostConstants.MAX_POST_BODY_LENGTH)
            throw new DomainArgumentException("O conteúdo desse post foi informado incorretamente.");

        Header = header;
        Body = body;
        ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }

    public void MakePrivate() => Private = true;

    public void MakePublic() => Private = false;
}