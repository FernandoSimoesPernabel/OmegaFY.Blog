using FluentAssertions;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class PostCommentsFacts
{
    [Fact]
    public void Comment_ValidComment_ShouldAddCommentToPost()
    {
        // Arrange
        PostComments postComments = new PostComments();
        Comment comment = new Comment(postComments.Id, new ReferenceId(Guid.NewGuid()), new Body("Content"));

        // Act
        postComments.Comment(comment);

        // Assert
        postComments.Comments.Should().ContainSingle(c => c == comment);
    }

    [Fact]
    public void Comment_InvalidPostId_ShouldThrowDomainArgumentException()
    {
        // Arrange
        PostComments postComments = new PostComments();
        Comment comment = new Comment(new ReferenceId(Guid.NewGuid()), new ReferenceId(Guid.NewGuid()), new Body("Content"));

        // Act
        Action act = () => postComments.Comment(comment);

        // Assert
        act.Should().Throw<DomainArgumentException>()
           .WithMessage("O comentário não pertence ao post atual.");
    }

    [Fact]
    public void EditComment_ValidComment_ShouldUpdateCommentContent()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Original Content"));
        postComments.Comment(comment);
        Body newBody = new Body("Updated Content");

        // Act
        postComments.EditComment(comment.Id, authorId, newBody);

        // Assert
        Comment updatedComment = postComments.FindCommentAndThrowIfNotFound(comment.Id, authorId);
        updatedComment.Body.Should().Be(newBody);
    }

    [Fact]
    public void ReactToComment_ValidReaction_ShouldAddReaction()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Content"));
        postComments.Comment(comment);

        // Act
        postComments.ReactToComment(comment.Id, authorId, CommentReaction.Like);

        // Assert
        Reaction reaction = postComments.FindReactionAndThrowIfNotFound(comment.Id, authorId);
        reaction.CommentReaction.Should().Be(CommentReaction.Like);
    }

    [Fact]
    public void ReactToComment_ExistingReaction_ShouldUpdateReaction()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Content"));
        postComments.Comment(comment);
        postComments.ReactToComment(comment.Id, authorId, CommentReaction.Like);

        // Act
        postComments.ChangeReactionToComment(comment.Id, authorId, CommentReaction.Dislike);

        // Assert
        Reaction reaction = postComments.FindReactionAndThrowIfNotFound(comment.Id, authorId);
        reaction.CommentReaction.Should().Be(CommentReaction.Dislike);
    }

    [Fact]
    public void RemoveComment_ValidComment_ShouldRemoveComment()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Content"));
        postComments.Comment(comment);

        // Act
        postComments.RemoveComment(comment.Id, authorId);

        // Assert
        postComments.Comments.Should().NotContain(comment);
    }

    [Fact]
    public void RemoveReactionFromComment_ValidReaction_ShouldRemoveReaction()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Content"));
        postComments.Comment(comment);
        postComments.ReactToComment(comment.Id, authorId, CommentReaction.Like);

        // Act
        postComments.RemoveReactionFromComment(comment.Id, authorId);

        // Assert
        Action act = () => postComments.FindReactionAndThrowIfNotFound(comment.Id, authorId);
        act.Should().Throw<NotFoundException>();
    }

    [Fact]
    public void Comment_ValidComment_ShouldAddComment()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Conteúdo do comentário"));

        // Act
        postComments.Comment(comment);

        // Assert
        postComments.Comments.Should().Contain(comment);
    }

    [Fact]
    public void Comment_NullComment_ShouldThrowDomainArgumentException()
    {
        // Arrange
        PostComments postComments = new PostComments();

        // Act & Assert
        Action action = () => postComments.Comment(null);
        action.Should().Throw<DomainArgumentException>()
            .WithMessage("Não foi informado nenhum comentário.");
    }

    [Fact]
    public void FindCommentAndThrowIfNotFound_ExistingComment_ShouldReturnComment()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Conteúdo do comentário"));
        postComments.Comment(comment);

        // Act
        Comment result = postComments.FindCommentAndThrowIfNotFound(comment.Id, authorId);

        // Assert
        result.Should().Be(comment);
    }

    [Fact]
    public void FindCommentAndThrowIfNotFound_NonexistentComment_ShouldThrowNotFoundException()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        ReferenceId nonExistentCommentId = new ReferenceId(Guid.NewGuid());

        // Act & Assert
        Action action = () => postComments.FindCommentAndThrowIfNotFound(nonExistentCommentId, authorId);
        action.Should().Throw<NotFoundException>();
    }

    [Fact]
    public void EditComment_ValidComment_ShouldUpdateComment()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Conteúdo original"));
        postComments.Comment(comment);

        // Act
        postComments.EditComment(comment.Id, authorId, new Body("Conteúdo editado"));

        // Assert
        comment.Body.Content.Should().Be("Conteúdo editado");
    }

    [Fact]
    public void RemoveComment_ExistingComment_ShouldRemoveComment()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Conteúdo do comentário"));
        postComments.Comment(comment);

        // Act
        postComments.RemoveComment(comment.Id, authorId);

        // Assert
        postComments.Comments.Should().NotContain(comment);
    }

    [Fact]
    public void ReactToComment_NewReaction_ShouldAddReaction()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Comentário com reação"));
        postComments.Comment(comment);

        // Act
        postComments.ReactToComment(comment.Id, authorId, CommentReaction.Like);

        // Assert
        comment.Reactions.Should().Contain(r => r.AuthorId == authorId && r.CommentReaction == CommentReaction.Like);
    }

    [Fact]
    public void RemoveReactionFromComment_ExistingReaction_ShouldRemoveReaction()
    {
        // Arrange
        PostComments postComments = new PostComments();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Comment comment = new Comment(postComments.Id, authorId, new Body("Comentário com reação"));
        postComments.Comment(comment);
        postComments.ReactToComment(comment.Id, authorId, CommentReaction.Like);

        // Act
        postComments.RemoveReactionFromComment(comment.Id, authorId);

        // Assert
        comment.Reactions.Should().BeEmpty();
    }
}