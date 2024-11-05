using FluentAssertions;
using OmegaFY.Blog.Domain.Exceptions;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.ValueObjects;

public class ReferenceIdFacts
{
    [Fact]
    public void Constructor_PassingValidGuid_ShouldCreateValidReferenceId()
    {
        //Arrange
        Guid validGuid = Guid.NewGuid();

        //Act
        ReferenceId sut = new ReferenceId(validGuid);

        //Assert
        sut.Value.Should().Be(validGuid);
    }

    [Fact]
    public void Construtor_PassingEmptyGuid_ShouldThrowDomainArgumentException()
    {
        //Arrange
        Guid emptyGuid = Guid.Empty;

        //Act
        Action sut = () => new ReferenceId(emptyGuid);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O Id precisa ser informado para um ReferenceId.");
    }

    [Fact]
    public void Constructor_PassingNewGuid_ShouldCreateUniqueReferenceId()
    {
        // Act
        ReferenceId referenceId1 = new ReferenceId(Guid.NewGuid());
        ReferenceId referenceId2 = new ReferenceId(Guid.NewGuid());

        // Assert
        referenceId1.Should().NotBe(referenceId2);
    }

    [Fact]
    public void ImplicitOperator_FromGuidToImplicitReferenceId_ShouldConvertToReferenceId()
    {
        //Arrange
        Guid validGuid = Guid.NewGuid();

        //Act
        ReferenceId sut = validGuid;

        //Assert
        sut.Value.Should().Be(validGuid);
    }

    [Fact]
    public void ImplicitOperator_FromReferenceIdToImplicitGuid_ShouldConvertToGuid()
    {
        //Arrange
        ReferenceId validReferenceId = new ReferenceId(Guid.NewGuid());

        //Act
        Guid sut = validReferenceId;

        //Assert
        sut.Should().Be(validReferenceId);
    }

    [Fact]
    public void GetHashCode_PassingGuid_ReferenceIdHashCodeShouldBeTheSameAsGuid()
    {
        //Arrange
        Guid validGuid = Guid.NewGuid();

        //Act
        ReferenceId sut = validGuid;

        //Assert
        sut.GetHashCode().Should().Be(validGuid.GetHashCode());
    }

    [Fact]
    public void ToString_PassingGuid_ReferenceIdToStringShouldBeTheSameAsGuid()
    {
        //Arrange
        ReferenceId validReferenceId = Guid.NewGuid();

        //Act
        Guid sut = validReferenceId;

        //Assert
        sut.GetHashCode().Should().Be(validReferenceId.GetHashCode());
    }

    [Fact]
    public void ToString_PassingGuid_ReferenceIdToStringShouldBeTheSameAsGuidString()
    {
        // Arrange
        ReferenceId validReferenceId = new ReferenceId(Guid.NewGuid());

        // Act
        string sut = validReferenceId.ToString();

        // Assert
        sut.Should().Be(validReferenceId.Value.ToString());
    }

    [Fact]
    public void Equality_PassingTwoReferenceIdsWithSameGuid_ShouldBeEqual()
    {
        // Arrange
        Guid guid = Guid.NewGuid();
        ReferenceId referenceId1 = new ReferenceId(guid);
        ReferenceId referenceId2 = new ReferenceId(guid);

        // Act & Assert
        referenceId1.Should().Be(referenceId2);
    }

    [Fact]
    public void Equality_PassingTwoReferenceIdsWithDifferentGuids_ShouldNotBeEqual()
    {
        // Arrange
        ReferenceId referenceId1 = new ReferenceId(Guid.NewGuid());
        ReferenceId referenceId2 = new ReferenceId(Guid.NewGuid());

        // Act & Assert
        referenceId1.Should().NotBe(referenceId2);
    }

    [Fact]
    public void Equality_ReferenceIdAndGuidWithSameGuid_ShouldBeEqual()
    {
        // Arrange
        Guid guid = Guid.NewGuid();
        ReferenceId referenceId = new ReferenceId(guid);

        // Act & Assert
        referenceId.Should().Be(guid);
    }
}