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
}