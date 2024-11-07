using FluentAssertions;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Exceptions;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class PostSharesFacts
{
    [Fact]
    public void Share_ValidShare_ShouldAddShare()
    {
        // Arrange
        PostShares postShares = new PostShares();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Shared shared = new Shared(postShares.Id, authorId);

        // Act
        postShares.Share(shared);

        // Assert
        postShares.Shareds.Should().Contain(shared);
    }

    [Fact]
    public void Share_NullShare_ShouldThrowDomainArgumentException()
    {
        // Arrange
        PostShares postShares = new PostShares();

        // Act & Assert
        Action action = () => postShares.Share(null);
        action.Should().Throw<DomainArgumentException>()
            .WithMessage("Não foi informado nenhum compartilhamento.");
    }

    [Fact]
    public void Share_InvalidPostId_ShouldThrowDomainArgumentException()
    {
        // Arrange
        PostShares postShares = new PostShares();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Shared invalidShared = new Shared(new ReferenceId(Guid.NewGuid()), authorId);

        // Act & Assert
        Action action = () => postShares.Share(invalidShared);
        action.Should().Throw<DomainArgumentException>()
            .WithMessage("O compartilhamento não pertence ao post atual.");
    }

    [Fact]
    public void Share_AuthorAlreadyShared_ShouldThrowConflictedException()
    {
        // Arrange
        PostShares postShares = new PostShares();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Shared shared = new Shared(postShares.Id, authorId);
        postShares.Share(shared);

        // Act & Assert
        Action action = () => postShares.Share(new Shared(postShares.Id, authorId));
        action.Should().Throw<ConflictedException>();
    }

    [Fact]
    public void Unshare_ExistingShare_ShouldRemoveShare()
    {
        // Arrange
        PostShares postShares = new PostShares();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Shared shared = new Shared(postShares.Id, authorId);
        postShares.Share(shared);

        // Act
        postShares.Unshare(authorId);

        // Assert
        postShares.Shareds.Should().NotContain(shared);
    }

    [Fact]
    public void Unshare_NonexistentShare_ShouldThrowNotFoundException()
    {
        // Arrange
        PostShares postShares = new PostShares();
        ReferenceId nonExistentAuthorId = new ReferenceId(Guid.NewGuid());

        // Act & Assert
        Action action = () => postShares.Unshare(nonExistentAuthorId);
        action.Should().Throw<NotFoundException>();
    }
}