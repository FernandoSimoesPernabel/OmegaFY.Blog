using FluentAssertions;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class PostAvaliationsFacts
{
    [Fact]
    public void RatePost_FirstRating_ShouldAddAvaliationAndCalculateAverageRate()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        Stars rating = Stars.Five;

        // Act
        sut.RatePost(authorId, rating);

        // Assert
        sut.Avaliations.Should().HaveCount(1);
        sut.AverageRate.Should().Be((double)rating);
    }

    [Fact]
    public void RatePost_SameAuthorRatingAgain_ShouldUpdateRatingAndRecalculateAverageRate()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        sut.RatePost(authorId, Stars.Five);

        // Act
        sut.RatePost(authorId, Stars.Two);

        // Assert
        sut.Avaliations.Should().HaveCount(1);
        sut.Avaliations.First().Rate.Should().Be(Stars.Two);
        sut.AverageRate.Should().Be((double)Stars.Two);
    }

    [Fact]
    public void RatePost_DifferentAuthors_ShouldAddAvaliationsAndCalculateCorrectAverageRate()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId author1Id = new ReferenceId(Guid.NewGuid());
        ReferenceId author2Id = new ReferenceId(Guid.NewGuid());

        // Act
        sut.RatePost(author1Id, Stars.Four);
        sut.RatePost(author2Id, Stars.Two);

        // Assert
        sut.Avaliations.Should().HaveCount(2);
        sut.AverageRate.Should().Be((4.0 + 2.0) / 2.0);
    }

    [Fact]
    public void ChangeUserRating_ExistingAvaliation_ShouldUpdateRatingAndRecalculateAverageRate()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        sut.RatePost(authorId, Stars.Five);

        // Act
        sut.ChangeUserRating(authorId, Stars.Three);

        // Assert
        sut.Avaliations.First().Rate.Should().Be(Stars.Three);
        sut.AverageRate.Should().Be((double)Stars.Three);
    }

    [Fact]
    public void ChangeUserRating_NonExistingAvaliation_ShouldThrowNotFoundException()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId nonExistingAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Action action = () => sut.ChangeUserRating(nonExistingAuthorId, Stars.Three);

        // Assert
        action.Should().Throw<NotFoundException>();
    }

    [Fact]
    public void RemoveRating_ExistingAvaliation_ShouldRemoveRatingAndRecalculateAverageRate()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId author1Id = new ReferenceId(Guid.NewGuid());
        ReferenceId author2Id = new ReferenceId(Guid.NewGuid());
        sut.RatePost(author1Id, Stars.Four);
        sut.RatePost(author2Id, Stars.Two);

        // Act
        sut.RemoveRating(author1Id);

        // Assert
        sut.Avaliations.Should().HaveCount(1);
        sut.AverageRate.Should().Be((double)Stars.Two);
    }

    [Fact]
    public void RemoveRating_NonExistingAvaliation_ShouldThrowNotFoundException()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId nonExistingAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Action action = () => sut.RemoveRating(nonExistingAuthorId);

        // Assert
        action.Should().Throw<NotFoundException>();
    }

    [Fact]
    public void HasAuthorAlreadyRatedPost_ExistingAuthor_ShouldReturnTrue()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());
        sut.RatePost(authorId, Stars.Five);

        // Act
        bool result = sut.HasAuthorAlreadyRatedPost(authorId);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void HasAuthorAlreadyRatedPost_NonExistingAuthor_ShouldReturnFalse()
    {
        // Arrange
        PostAvaliations sut = new PostAvaliations();
        ReferenceId authorId = new ReferenceId(Guid.NewGuid());

        // Act
        bool result = sut.HasAuthorAlreadyRatedPost(authorId);

        // Assert
        result.Should().BeFalse();
    }
}