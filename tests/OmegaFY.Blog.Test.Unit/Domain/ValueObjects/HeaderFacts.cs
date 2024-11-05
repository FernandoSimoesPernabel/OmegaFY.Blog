using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.ValueObjects;

public class HeaderFacts
{
    [Fact]
    public void Constructor_PassingValidTitleAndSubTitle_ShouldCreateHeader()
    {
        //Arrange
        Lorem lorem = new Faker().Lorem;

        string title = lorem.Letter(50);

        string subTitle = lorem.Letter(50);

        //Act
        Header sut = new Header(title, subTitle);

        //Assert
        sut.Title.Should().Be(title);
        sut.SubTitle.Should().Be(subTitle);
    }

    [Fact]
    public void Constructor_PassingEmptyTitle_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string emptyTitle = "";
        string subTitle = new Faker().Lorem.Letter(50);

        // Act
        Action sut = () => new Header(emptyTitle, subTitle);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O título do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingWhitespaceTitle_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string whitespaceTitle = "   ";
        string subTitle = new Faker().Lorem.Letter(50);

        // Act
        Action sut = () => new Header(whitespaceTitle, subTitle);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O título do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingEmptySubTitle_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string title = new Faker().Lorem.Letter(50);
        string emptySubTitle = "";

        // Act
        Action sut = () => new Header(title, emptySubTitle);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O subtítulo do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingWhitespaceSubTitle_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string title = new Faker().Lorem.Letter(50);
        string whitespaceSubTitle = "   ";

        // Act
        Action sut = () => new Header(title, whitespaceSubTitle);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O subtítulo do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingOutOfRangeTitle_ShouldThrowDomainArgumentException()
    {
        //Arrange
        Lorem lorem = new Faker().Lorem;

        string outRangeTitle = lorem.Letter(100);

        string subTitle = lorem.Letter(50);

        //Act
        Action sut = () => new Header(outRangeTitle, subTitle);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O título do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingNullTitle_ShouldThrowDomainArgumentException()
    {
        //Arrange
        string nullTitle = null;
        string subTitle = new Faker().Lorem.Letter(50);

        //Act
        Action sut = () => new Header(nullTitle, subTitle);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O título do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingOutOfRangeSubTitle_ShouldThrowDomainArgumentException()
    {
        //Arrange
        Lorem lorem = new Faker().Lorem;

        string title = lorem.Letter(50);

        string outRangeSubTitle = lorem.Letter(100);

        //Act
        Action sut = () => new Header(title, outRangeSubTitle);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O subtítulo do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Constructor_PassingNullSubTitle_ShouldThrowDomainArgumentException()
    {
        //Arrange
        string title = new Faker().Lorem.Letter(50);
        string nullSubTitle = null;

        //Act
        Action sut = () => new Header(title, nullSubTitle);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O subtítulo do cabeçalho precisa ser informato com até 50 caracteres.");
    }

    [Fact]
    public void Equality_SameTitleAndSubTitle_ShouldBeEqual()
    {
        // Arrange
        string title = new Faker().Lorem.Letter(30);
        string subTitle = new Faker().Lorem.Letter(30);

        Header header1 = new Header(title, subTitle);
        Header header2 = new Header(title, subTitle);

        // Act & Assert
        header1.Should().Be(header2);
    }

    [Fact]
    public void Inequality_DifferentTitleOrSubTitle_ShouldNotBeEqual()
    {
        // Arrange
        string title1 = new Faker().Lorem.Letter(30);
        string subTitle1 = new Faker().Lorem.Letter(30);

        Header header1 = new Header(title1, subTitle1);
        Header header2 = new Header(new Faker().Lorem.Letter(30), new Faker().Lorem.Letter(30));

        // Act & Assert
        header1.Should().NotBe(header2);
    }
}