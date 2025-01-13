using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class CommentFacts
{
    private readonly Faker _faker = new();

    [Fact]
    public void Constructor_PassingValidParameters_ShouldCreateComment()
    {
        // Arrange
        ReferenceId postId = new ReferenceId(Guid.NewGuid());
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Body body = new Body(_faker.Lorem.Letter(PostConstants.MIN_COMMENT_BODY_LENGTH));

        // Act
        Comment sut = new Comment(postId, authorId, body);

        // Assert
        sut.PostId.Should().Be(postId);
        sut.AuthorId.Should().Be(authorId);
        sut.Body.Should().Be(body);
        sut.Reactions.Should().BeEmpty();
        sut.ModificationDetails.Should().NotBeNull();
    }

    [Fact]
    public void ChangeContent_PassingValidBody_ShouldUpdateBodyAndModificationDetails()
    {
        // Arrange
        Comment sut = CreateComment();
        Body newBody = new Body(_faker.Lorem.Letter(PostConstants.MIN_COMMENT_BODY_LENGTH));

        // Act
        sut.ChangeContent(newBody);

        // Assert
        sut.Body.Should().Be(newBody);
        sut.ModificationDetails.DateOfModification.Should().NotBeNull();
    }

    [Fact]
    public void ChangeContent_PassingLongBody_ShouldThrowDomainArgumentException()
    {
        // Arrange
        Comment sut = CreateComment();
        Body longBody = new Body(_faker.Lorem.Letter(PostConstants.MAX_COMMENT_BODY_LENGTH + 1));

        // Act
        Action action = () => sut.ChangeContent(longBody);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("O máximo de caracteres de um comentário é 500.");
    }

    [Theory]
    [InlineData(CommentReaction.Like)]
    [InlineData(CommentReaction.Dislike)]
    [InlineData(CommentReaction.Loved)]
    [InlineData(CommentReaction.Claps)]
    [InlineData(CommentReaction.Genius)]
    [InlineData(CommentReaction.Interesting)]
    public void React_PassingValidReactions_ShouldStoreReaction(CommentReaction commentReaction)
    {
        // Arrange
        Comment sut = CreateComment();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Reaction reaction = CreateReaction(sut.Id, authorId, commentReaction);

        // Act
        sut.React(reaction);

        // Assert
        sut.Reactions.Should().ContainSingle(r => r.CommentReaction == commentReaction && r.AuthorId == authorId);
    }

    [Fact]
    public void React_PassingValidReaction_ShouldAddReactionToComment()
    {
        // Arrange
        Comment sut = CreateComment();
        Reaction reaction = CreateReaction(sut.Id);

        // Act
        sut.React(reaction);

        // Assert
        sut.Reactions.Should().ContainSingle().Which.Should().Be(reaction);
    }

    [Fact]
    public void React_PassingNullReaction_ShouldThrowDomainArgumentException()
    {
        // Arrange
        Comment sut = CreateComment();

        // Act
        Action action = () => sut.React(null);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("Não foi informada uma reação.");
    }

    [Fact]
    public void React_PassingReactionWithMismatchedCommentId_ShouldThrowDomainArgumentException()
    {
        // Arrange
        Comment sut = CreateComment();
        Reaction mismatchedReaction = CreateReaction(Guid.NewGuid());

        // Act
        Action action = () => sut.React(mismatchedReaction);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("O Id da reação não bate com o comentário atual.");
    }

    [Fact]
    public void React_WithMultipleReactions_ShouldStoreAllReactions()
    {
        // Arrange
        Comment sut = CreateComment();

        // Act
        sut.React(CreateReaction(sut.Id, Guid.NewGuid(), CommentReaction.Like));
        sut.React(CreateReaction(sut.Id, Guid.NewGuid(), CommentReaction.Dislike));
        sut.React(CreateReaction(sut.Id, Guid.NewGuid(), CommentReaction.Loved));

        // Assert
        sut.Reactions.Count.Should().Be(3);
    }

    [Fact]
    public void HasAuthorAlreadyReactToComment_AuthorReacted_ShouldReturnTrue()
    {
        // Arrange
        Comment sut = CreateComment();
        Reaction reaction = CreateReaction(sut.Id);
        sut.React(reaction);

        // Act
        bool result = sut.HasAuthorAlreadyReactToComment(reaction.AuthorId);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void HasAuthorAlreadyReactToComment_AuthorNotReacted_ShouldReturnFalse()
    {
        // Arrange
        Comment sut = CreateComment();
        ReferenceId differentAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        bool result = sut.HasAuthorAlreadyReactToComment(differentAuthorId);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void ChangeReaction_PassingValidAuthorIdAndNewReaction_ShouldUpdateReaction()
    {
        // Arrange
        Comment sut = CreateComment();
        Reaction reaction = CreateReaction(sut.Id);
        sut.React(reaction);
        CommentReaction newReactionType = CommentReaction.Like;

        // Act
        sut.ChangeReaction(reaction.AuthorId, newReactionType);

        // Assert
        reaction.CommentReaction.Should().Be(newReactionType);
    }

    [Fact]
    public void ChangeReaction_PassingNonExistentAuthorId_ShouldThrowNotFoundException()
    {
        // Arrange
        Comment sut = CreateComment();
        ReferenceId nonExistentAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Action action = () => sut.ChangeReaction(nonExistentAuthorId, CommentReaction.Like);

        // Assert
        action.Should().Throw<NotFoundException>();
    }

    [Theory]
    [InlineData(CommentReaction.Like)]
    [InlineData(CommentReaction.Dislike)]
    [InlineData(CommentReaction.Loved)]
    [InlineData(CommentReaction.Claps)]
    [InlineData(CommentReaction.Genius)]
    [InlineData(CommentReaction.Interesting)]
    public void ChangeReaction_WithValidReaction_ShouldUpdateReaction(CommentReaction newReaction)
    {
        // Arrange
        Comment sut = CreateComment();
        Reaction reaction = CreateReaction(sut.Id);
        sut.React(reaction);

        // Act
        sut.ChangeReaction(reaction.AuthorId, newReaction);

        // Assert
        reaction.CommentReaction.Should().Be(newReaction);
    }

    [Fact]
    public void RemoveReaction_PassingValidAuthorId_ShouldRemoveReaction()
    {
        // Arrange
        Comment sut = CreateComment();
        Reaction reaction = CreateReaction(sut.Id);
        sut.React(reaction);

        // Act
        sut.RemoveReaction(reaction.AuthorId);

        // Assert
        sut.Reactions.Should().BeEmpty();
    }

    [Fact]
    public void RemoveReaction_PassingNonExistentAuthorId_ShouldThrowNotFoundException()
    {
        // Arrange
        Comment sut = CreateComment();
        ReferenceId nonExistentAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Action action = () => sut.RemoveReaction(nonExistentAuthorId);

        // Assert
        action.Should().Throw<NotFoundException>();
    }

    private Comment CreateComment()
    {
        ReferenceId postId = new ReferenceId(Guid.NewGuid());

        ReferenceId authorId = new ReferenceId(Guid.NewGuid());

        Body body = new Body(_faker.Lorem.Letter(PostConstants.MIN_COMMENT_BODY_LENGTH));

        return new Comment(postId, authorId, body);
    }

    private Reaction CreateReaction(Guid commentId)
        => new Reaction(new ReferenceId(commentId), new ReferenceId(Guid.NewGuid()), CommentReaction.Like);

    private Reaction CreateReaction(ReferenceId commentId, Guid authorId, CommentReaction commentReaction) 
        => new Reaction(commentId, new ReferenceId(authorId), commentReaction);
}