using FluentAssertions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class ReactionFacts
{
    [Fact]
    public void Constructor_PassingValidCommentIdAuthorIdAndCommentReaction_ShouldCreateValidReaction()
    {
        // Arrange
        ReferenceId validCommentId = new ReferenceId(Guid.NewGuid());
        ReferenceId validAuthorId = new ReferenceId(Guid.NewGuid());
        CommentReaction validReaction = CommentReaction.Like;

        // Act
        Reaction sut = new Reaction(validCommentId, validAuthorId, validReaction);

        // Assert
        sut.CommentId.Should().Be(validCommentId);
        sut.AuthorId.Should().Be(validAuthorId);
        sut.CommentReaction.Should().Be(validReaction);
    }

    [Fact]
    public void Constructor_PassingUndefinedCommentReaction_ShouldThrowDomainArgumentException()
    {
        // Arrange
        ReferenceId validCommentId = new ReferenceId(Guid.NewGuid());
        ReferenceId validAuthorId = new ReferenceId(Guid.NewGuid());
        CommentReaction undefinedReaction = (CommentReaction)999;

        // Act
        Action sut = () => new Reaction(validCommentId, validAuthorId, undefinedReaction);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("A reação informada não é válida.");
    }

    [Theory]
    [InlineData(CommentReaction.Like)]
    [InlineData(CommentReaction.Dislike)]
    [InlineData(CommentReaction.Loved)]
    [InlineData(CommentReaction.Claps)]
    [InlineData(CommentReaction.Genius)]
    [InlineData(CommentReaction.Interesting)]
    public void Constructor_PassingEachValidCommentReaction_ShouldCreateReactionWithSpecifiedCommentReaction(CommentReaction commentReaction)
    {
        // Arrange
        ReferenceId validCommentId = new ReferenceId(Guid.NewGuid());
        ReferenceId validAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Reaction sut = new Reaction(validCommentId, validAuthorId, commentReaction);

        // Assert
        sut.CommentReaction.Should().Be(commentReaction);
    }

    [Theory]
    [InlineData(CommentReaction.Like)]
    [InlineData(CommentReaction.Dislike)]
    [InlineData(CommentReaction.Loved)]
    [InlineData(CommentReaction.Claps)]
    [InlineData(CommentReaction.Genius)]
    [InlineData(CommentReaction.Interesting)]
    public void ChangeCommentReaction_PassingEachValidCommentReaction_ShouldUpdateCommentReaction(CommentReaction newReaction)
    {
        // Arrange
        ReferenceId validCommentId = new ReferenceId(Guid.NewGuid());
        ReferenceId validAuthorId = new ReferenceId(Guid.NewGuid());
        Reaction sut = new Reaction(validCommentId, validAuthorId, CommentReaction.Like); // Inicializado com uma reação

        // Act
        sut.ChangeCommentReaction(newReaction);

        // Assert
        sut.CommentReaction.Should().Be(newReaction);
    }

    [Fact]
    public void ChangeCommentReaction_PassingValidCommentReaction_ShouldUpdateCommentReaction()
    {
        // Arrange
        Reaction sut = new Reaction(new ReferenceId(Guid.NewGuid()), new ReferenceId(Guid.NewGuid()), CommentReaction.Like);

        // Act
        sut.ChangeCommentReaction(CommentReaction.Dislike);

        // Assert
        sut.CommentReaction.Should().Be(CommentReaction.Dislike);
    }

    [Fact]
    public void ChangeCommentReaction_PassingUndefinedCommentReaction_ShouldThrowDomainArgumentException()
    {
        // Arrange
        Reaction sut = new Reaction(new ReferenceId(Guid.NewGuid()), new ReferenceId(Guid.NewGuid()), CommentReaction.Like);
        CommentReaction undefinedReaction = (CommentReaction)999;

        // Act
        Action changeReaction = () => sut.ChangeCommentReaction(undefinedReaction);

        // Assert
        changeReaction.Should().Throw<DomainArgumentException>().WithMessage("A reação informada não é válida.");
    }
}