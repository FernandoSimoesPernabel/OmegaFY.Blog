using FluentAssertions;
using OmegaFY.Blog.Domain.Entities.Shares;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class SharedFacts
{
    [Fact]
    public void Constructor_PassingValidPostIdAndAuthorId_ShouldCreateSharedWithCorrectValues()
    {
        // Arrange
        ReferenceId validPostId = new ReferenceId(Guid.NewGuid());
        ReferenceId validAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Shared sut = new Shared(validPostId, validAuthorId);

        // Assert
        sut.PostId.Should().Be(validPostId);
        sut.AuthorId.Should().Be(validAuthorId);
        sut.DateAndTimeOfShare.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
    }

    [Fact]
    public void Constructor_PassingValidPostIdAndAuthorId_ShouldSetDateAndTimeOfShareToUtcNow()
    {
        // Arrange
        ReferenceId validPostId = new ReferenceId(Guid.NewGuid());
        ReferenceId validAuthorId = new ReferenceId(Guid.NewGuid());

        // Act
        Shared sut = new Shared(validPostId, validAuthorId);

        // Assert
        sut.DateAndTimeOfShare.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
    }
}