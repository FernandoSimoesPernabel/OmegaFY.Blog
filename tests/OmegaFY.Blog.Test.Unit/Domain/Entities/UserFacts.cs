using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Users;
using OmegaFY.Blog.Domain.Exceptions;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class UserFacts
{
    private readonly Faker _faker = new();

    [Fact]
    public void Constructor_PassingValidEmailAndDisplayName_ShouldCreateUser()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        string validDisplayName = _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH);

        // Act
        User sut = new User(validEmail, validDisplayName);

        // Assert
        sut.Email.Should().Be(validEmail);
        sut.DisplayName.Should().Be(validDisplayName);
    }

    [Fact]
    public void Constructor_PassingInvalidEmail_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string invalidEmail = _faker.Lorem.Letter(UserConstants.MAX_EMAIL_LENGTH + 1);
        string validDisplayName = _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH);

        // Act
        Action sut = () => new User(invalidEmail, validDisplayName);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O Email informado esta inválido.");
    }

    [Fact]
    public void Constructor_PassingEmptyEmail_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string emptyEmail = string.Empty;
        string validDisplayName = _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH);

        // Act
        Action sut = () => new User(emptyEmail, validDisplayName);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O Email informado esta inválido.");
    }

    [Fact]
    public void Constructor_PassingEmptyDisplayName_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        string emptyDisplayName = string.Empty;

        // Act
        Action sut = () => new User(validEmail, emptyDisplayName);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado um nome para o usuário");
    }

    [Fact]
    public void Constructor_PassingShortDisplayName_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        string shortDisplayName = _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH - 1);

        // Act
        Action sut = () => new User(validEmail, shortDisplayName);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O nome de usuário deve ter entre 3 e 100.");
    }

    [Fact]
    public void Constructor_PassingLongDisplayName_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        string longDisplayName = _faker.Lorem.Letter(UserConstants.MAX_DISPLAY_NAME_LENGTH + 1);

        // Act
        Action sut = () => new User(validEmail, longDisplayName);

        // Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O nome de usuário deve ter entre 3 e 100.");
    }

    [Fact]
    public void ChangeDisplayName_PassingValidDisplayName_ShouldUpdateDisplayName()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        User sut = new User(validEmail, _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH));
        string newDisplayName = _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH);

        // Act
        sut.ChangeDisplayName(newDisplayName);

        // Assert
        sut.DisplayName.Should().Be(newDisplayName);
    }

    [Fact]
    public void ChangeDisplayName_PassingEmptyDisplayName_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        User sut = new User(validEmail, _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH));

        // Act
        Action action = () => sut.ChangeDisplayName("");

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado um nome para o usuário");
    }

    [Fact]
    public void ChangeDisplayName_PassingShortDisplayName_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        User sut = new User(validEmail, _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH));
        string shortDisplayName = _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH - 1);

        // Act
        Action action = () => sut.ChangeDisplayName(shortDisplayName);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("O nome de usuário deve ter entre 3 e 100.");
    }

    [Fact]
    public void ChangeDisplayName_PassingLongDisplayName_ShouldThrowDomainArgumentException()
    {
        // Arrange
        string validEmail = _faker.Internet.Email();
        User sut = new User(validEmail, _faker.Lorem.Letter(UserConstants.MIN_DISPLAY_NAME_LENGTH));
        string longDisplayName = _faker.Lorem.Letter(UserConstants.MAX_DISPLAY_NAME_LENGTH + 1);

        // Act
        Action action = () => sut.ChangeDisplayName(longDisplayName);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("O nome de usuário deve ter entre 3 e 100.");
    }
}
