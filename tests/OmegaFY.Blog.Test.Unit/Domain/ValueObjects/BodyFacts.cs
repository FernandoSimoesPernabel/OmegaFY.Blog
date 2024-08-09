using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.ValueObjects;

public class BodyFacts
{
    [Fact]
    public void Constructor_PassingValidBodyContent_ShouldCreateBody()
    {
        //Arrange
        string validContent = new Faker().Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = validContent;

        //Assert
        sut.Content.Should().Be(validContent);
    }

    [Fact]
    public void Constructor_PassingNullBodyContent_ShouldThrowDomainArgumentException()
    {
        //Arrange
        string nullBodyContent = null;

        //Act
        Action sut = () => new Body(nullBodyContent);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado nenhum conteudo para o corpo.");
    }

    [Fact]
    public void Constructor_PassingEmptyBodyContent_ShouldThrowDomainArgumentException()
    {
        //Arrange
        string emptyBodyContent = string.Empty;

        //Act
        Action sut = () => new Body(emptyBodyContent);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado nenhum conteudo para o corpo.");
    }

    [Fact]
    public void ImplicitOperator_FromBodyToImplictString_ShouldConvertToString()
    {
        //Arrange
        Body validBody = new Faker().Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        string sut = validBody;

        //Assert
        sut.Should().Be(validBody);
    }

    [Fact]
    public void ImplicitOperator_FromStringToImplictBody_ShouldConvertToBody()
    {
        //Arrange
        string validContent = new Faker().Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = validContent;

        //Assert
        sut.Content.Should().Be(validContent);
    }

    [Fact]
    public void GetHashCode_PassingStringBodyContent_BodyHashCodeShouldBeTheSameAsString()
    {
        //Arrange
        string validContent = new Faker().Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = validContent;

        //Assert
        sut.GetHashCode().Should().Be(validContent.GetHashCode());
    }

    [Fact]
    public void ToString_PassingStringBodyContent_BodyToStringShouldBeTheSameAsString()
    {
        //Arrange
        string validContent = new Faker().Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = new Body(validContent);

        //Assert
        sut.ToString().Should().Be(validContent.ToString());
    }
}