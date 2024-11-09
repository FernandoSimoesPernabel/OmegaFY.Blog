using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.ValueObjects;

public class BodyFacts
{
    private readonly Faker _faker = new();

    [Fact]
    public void Constructor_PassingValidBodyContent_ShouldCreateBody()
    {
        //Arrange
        string validContent = _faker.Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

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
    public void Constructor_MaxLengthBodyContent_ShouldCreateBody()
    {
        // Arrange
        string maxLengthContent = _faker.Lorem.Letter(PostConstants.MAX_POST_BODY_LENGTH);

        // Act
        Body sut = maxLengthContent;

        // Assert
        sut.Content.Should().Be(maxLengthContent);
    }

    [Fact]
    public void Constructor_WhitespaceBodyContent_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string whitespaceContent = "     ";

        // Act
        Action sut = () => new Body(whitespaceContent);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado nenhum conteudo para o corpo.");
    }

    [Fact]
    public void Constructor_ContentWithSpecialCharacters_ShouldCreateBody()
    {
        // Arrange
        string specialCharContent = _faker.Lorem.Sentence() + "!@#$%^&*()";

        // Act
        Body sut = specialCharContent;

        // Assert
        sut.Content.Should().Be(specialCharContent);
    }

    [Fact]
    public void ImplicitOperator_FromBodyToImplictString_ShouldConvertToString()
    {
        //Arrange
        Body validBody = _faker.Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        string sut = validBody;

        //Assert
        sut.Should().Be(validBody);
    }

    [Fact]
    public void ImplicitOperator_FromStringToImplictBody_ShouldConvertToBody()
    {
        //Arrange
        string validContent = _faker.Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = validContent;

        //Assert
        sut.Content.Should().Be(validContent);
    }

    [Fact]
    public void GetHashCode_PassingStringBodyContent_BodyHashCodeShouldBeTheSameAsString()
    {
        //Arrange
        string validContent = _faker.Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = validContent;

        //Assert
        sut.GetHashCode().Should().Be(validContent.GetHashCode());
    }

    [Fact]
    public void ToString_PassingStringBodyContent_BodyToStringShouldBeTheSameAsString()
    {
        //Arrange
        string validContent = _faker.Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));

        //Act
        Body sut = new Body(validContent);

        //Assert
        sut.ToString().Should().Be(validContent.ToString());
    }

    [Fact]
    public void Equality_SameContentBodies_ShouldBeEqual()
    {
        // Arrange
        string content = _faker.Lorem.Letter(100);
        Body body1 = new Body(content);
        Body body2 = new Body(content);

        // Act & Assert
        body1.Should().Be(body2);
    }

    [Fact]
    public void Inequality_DifferentContentBodies_ShouldNotBeEqual()
    {
        // Arrange
        Body body1 = new Body(_faker.Lorem.Letter(100));
        Body body2 = new Body(_faker.Lorem.Letter(100));

        // Act & Assert
        body1.Should().NotBe(body2);
    }
}