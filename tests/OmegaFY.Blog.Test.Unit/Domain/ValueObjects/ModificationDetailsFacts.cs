using FluentAssertions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.ValueObjects;

public class ModificationDetailsFacts
{
    public static readonly TheoryData<DateTime> DATE_TIMES_THEORY_DATA = new()
    {
        new DateTime(DateTime.Now.Year, 1, 1),
        new DateTime(DateTime.Now.Year, 2, 2),
        new DateTime(DateTime.Now.Year, 3, 3),
        new DateTime(DateTime.Now.Year,4, 4),
        new DateTime(DateTime.Now.Year, 5, 5),
        new DateTime(DateTime.Now.Year, 6, 6),
        new DateTime(DateTime.Now.Year, 7, 7),
        new DateTime(DateTime.Now.Year, 8, 8),
        new DateTime(DateTime.Now.Year, 9, 9),
        new DateTime(DateTime.Now.Year, 10, 10),
        new DateTime(DateTime.Now.Year, 11, 11),
        new DateTime(DateTime.Now.Year, 12, 12)
    };

    [Fact]
    public void Construtor_PassingNoParameters_ShouldHaveUtcNowDateOfCreationAndNullDateOfModification()
    {
        //Act
        ModificationDetails sut = new ModificationDetails();

        //Assert
        sut.DateOfCreation.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
        sut.DateOfModification.Should().BeNull();
    }

    [Theory, MemberData(nameof(DATE_TIMES_THEORY_DATA))]
    public void Construtor_PassingDateOfCreation_ShouldHaveDateOfCreationAndUtcNowDateOfModification(DateTime dateOfCreation)
    {
        ModificationDetails sut = new ModificationDetails(dateOfCreation);

        //Assert
        sut.DateOfCreation.Should().Be(dateOfCreation);
        sut.DateOfModification.Should().NotBeNull();
        sut.DateOfModification.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
    }
}