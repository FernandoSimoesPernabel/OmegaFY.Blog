using FluentAssertions;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class AvaliationFacts
{
    [Fact]
    public void Constructor_PassingValidParameters_ShouldCreateValidAvaliation()
    {
        // Arrange
        ReferenceId postId = new ReferenceId(Guid.NewGuid());
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Stars rating = Stars.Five;

        // Act
        Avaliation sut = new Avaliation(postId, authorId, rating);

        // Assert
        sut.PostId.Should().Be(postId);
        sut.AuthorId.Should().Be(authorId);
        sut.Rate.Should().Be(rating);
        sut.ModificationDetails.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_PassingInvalidRating_ShouldThrowDomainArgumentException()
    {
        // Arrange
        ReferenceId postId = new ReferenceId(Guid.NewGuid());
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Stars invalidRating = (Stars)11;

        // Act
        Action sut = () => new Avaliation(postId, authorId, invalidRating);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("A avaliação informada está fora do range aceitado.");
    }

    [Theory]
    [InlineData(Stars.Zero)]
    [InlineData(Stars.One)]
    [InlineData(Stars.Two)]
    [InlineData(Stars.Three)]
    [InlineData(Stars.Four)]
    [InlineData(Stars.Five)]
    [InlineData(Stars.Six)]
    [InlineData(Stars.Seven)]
    [InlineData(Stars.Eight)]
    [InlineData(Stars.Nine)]
    [InlineData(Stars.Ten)]
    public void ChangeRating_PassingValidStars_ShouldChangeRating(Stars rating)
    {
        // Arrange
        ReferenceId postId = new ReferenceId(Guid.NewGuid());
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Avaliation sut = new Avaliation(postId, authorId, Stars.Five);

        // Act
        sut.ChangeRating(rating);

        // Assert
        sut.Rate.Should().Be(rating);
    }

    [Fact]
    public void ChangeRating_PassingInvalidStars_ShouldThrowDomainArgumentException()
    {
        // Arrange
        ReferenceId postId = new ReferenceId(Guid.NewGuid());
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Avaliation sut = new Avaliation(postId, authorId, Stars.Five);
        Stars invalidRating = (Stars)11;

        // Act
        Action action = () => sut.ChangeRating(invalidRating);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("A avaliação informada está fora do range aceitado.");
    }
}