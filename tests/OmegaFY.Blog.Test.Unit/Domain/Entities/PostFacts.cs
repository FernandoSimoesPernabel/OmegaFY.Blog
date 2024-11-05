using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class PostFacts
{
    private readonly Faker _faker = new();

    [Fact]
    public void Constructor_PassingValidAuthor_ShouldPublishedPost()
    {
        //Arrange
        ReferenceId authorId = Guid.NewGuid();

        //Act
        Post sut = CreatePost(authorId: authorId);

        //Assert
        sut.AuthorId.Should().Be(authorId);
    }

    [Fact]
    public void Constructor_PassingValidHeader_ShouldPublishedPost()
    {
        //Arrange
        Header validHeader = CreateHeader();

        //Act
        Post sut = CreatePost(header: validHeader);

        //Assert
        sut.Header.Should().NotBeNull();
        sut.Header.Should().BeEquivalentTo(validHeader);
    }

    [Fact]
    public void Constructor_PassingNullHeader_ShouldThrowDomainArgumentException()
    {
        //Arrange
        Header nullHeader = null;

        //Act
        Action sut = () => new Post(CreateAuthor(), nullHeader, CreateBody());

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado corretamente um cabeçalho para esse post.");
    }

    [Fact]
    public void Constructor_PassingValidBody_ShouldCreatePost()
    {
        //Arrange
        Body validBody = CreateBody();

        //Act
        Post sut = CreatePost(body: validBody);

        //Assert
        sut.Body.Should().BeEquivalentTo(validBody);
    }

    [Theory]
    [InlineData(3120)]
    [InlineData(326)]
    [InlineData(1236)]
    [InlineData(5000)]
    [InlineData(1)]
    [InlineData(4935)]
    [InlineData(22)]
    [InlineData(121)]
    [InlineData(33)]
    public void Constructor_PassingInRangeBody_ShouldPublishedPost(short bodyContentSize)
    {
        //Arrange
        Body inRangeBody = new Faker().Random.AlphaNumeric(bodyContentSize);

        //Act
        Post sut = new Post(CreateAuthor(), CreateHeader(), inRangeBody);

        //Assert
        sut.Body.Should().BeEquivalentTo(inRangeBody);
    }

    [Theory]
    [InlineData(3120)]
    [InlineData(326)]
    [InlineData(1236)]
    [InlineData(5000)]
    [InlineData(1)]
    [InlineData(4935)]
    [InlineData(22)]
    [InlineData(121)]
    [InlineData(33)]
    public void Constructor_PassingOutOfRangeBody_ShouldThrowDomainArgumentException(short bodyContentSize)
    {
        //Arrange
        Body outOfRangeBody = new Faker().Random.AlphaNumeric(PostConstants.MAX_POST_BODY_LENGTH + bodyContentSize);

        //Act
        Action sut = () => new Post(CreateAuthor(), CreateHeader(), outOfRangeBody);

        //Assert
        sut.Should().Throw<DomainArgumentException>().WithMessage("O conteúdo desse post foi informado incorretamente.");
    }

    [Fact]
    public void Constructor_CreatingValidPost_ShouldHaveModificationDetailsDateOfCreationEqualsToUtcNow()
    {
        //Arrange
        Post sut = null;

        //Act
        sut = CreatePost();

        //Assert
        sut.ModificationDetails.Should().NotBeNull();
        sut.ModificationDetails.DateOfCreation.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
    }

    [Fact]
    public void Constructor_CreatingValidPost_ShouldHaveModificationDetailsDateOfModificationEqualsToNull()
    {
        //Arrange
        Post sut = null;

        //Act
        sut = CreatePost();

        //Assert
        sut.ModificationDetails.Should().NotBeNull();
        sut.ModificationDetails.DateOfModification.Should().BeNull();
    }

    [Fact]
    public void Constructor_ModifiedPost_ShouldHaveModificationDetailsDateOfModificationEqualsToUtcNow()
    {
        //Arrange
        Post sut = CreatePost();

        //Act
        sut.ChangeContent(CreateHeader(), CreateBody());

        //Assert
        sut.ModificationDetails.Should().NotBeNull();
        sut.ModificationDetails.DateOfModification.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
    }

    [Fact]
    public void ChangeContent_Published_ShouldChangeHeader()
    {
        //Arrange
        Post sut = CreatePost();
        Header newHeader = CreateHeader();

        //Act
        sut.ChangeContent(newHeader, CreateBody());

        //Assert
        sut.Header.Should().BeEquivalentTo(newHeader);
    }

    [Fact]
    public void ChangeContent_Published_ShouldChangeBody()
    {
        //Arrange
        Post sut = CreatePost();
        Body newBody = CreateBody();

        //Act
        sut.ChangeContent(CreateHeader(), newBody);

        //Assert
        sut.Body.Should().BeEquivalentTo(newBody);
    }

    [Fact]
    public void ChangeContent_NullHeader_ShouldThrowDomainArgumentException()
    {
        // Arrange
        Post sut = CreatePost();

        // Act
        Action action = () => sut.ChangeContent(null, CreateBody());

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("Não foi informado corretamente um cabeçalho para esse post.");
    }

    [Fact]
    public void ChangeContent_BodyExceedsMaxLength_ShouldThrowDomainArgumentException()
    {
        // Arrange
        Post sut = CreatePost();
        Body outOfRangeBody = new Faker().Lorem.Letter(PostConstants.MAX_POST_BODY_LENGTH + 1);

        // Act
        Action action = () => sut.ChangeContent(CreateHeader(), outOfRangeBody);

        // Assert
        action.Should().Throw<DomainArgumentException>().WithMessage("O conteúdo desse post foi informado incorretamente.");
    }

    [Fact]
    public void ChangeContent_ValidHeaderAndBody_ShouldUpdateDateOfModificationAndPreserveDateOfCreation()
    {
        // Arrange
        Post sut = CreatePost();
        DateTime initialDateOfCreation = sut.ModificationDetails.DateOfCreation;

        // Act
        sut.ChangeContent(CreateHeader(), CreateBody());

        // Assert
        sut.ModificationDetails.DateOfModification.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
        sut.ModificationDetails.DateOfCreation.Should().Be(initialDateOfCreation);
    }


    [Fact]
    public void MakePrivate_PublicPost_ShouldBecomePrivate()
    {
        //Arrange
        Post sut = CreatePost();

        //Act
        sut.MakePrivate();

        //Assert
        sut.Private.Should().BeTrue();
    }

    [Fact]
    public void MakePrivate_PrivatePost_ShouldRemainsPrivate()
    {
        //Arrange
        Post sut = CreatePost();

        //Act
        sut.MakePrivate();
        sut.MakePrivate();

        //Assert
        sut.Private.Should().BeTrue();
    }

    [Fact]
    public void MakePublic_PrivatePost_ShouldBecomePublic()
    {
        //Arrange
        Post sut = CreatePost(@private: true);

        //Act
        sut.MakePublic();

        //Assert
        sut.Private.Should().BeFalse();
    }

    [Fact]
    public void MakePublic_PublicPost_ShouldRemainsPublic()
    {
        //Arrange
        Post sut = CreatePost();

        //Act
        sut.MakePublic();

        //Assert
        sut.Private.Should().BeFalse();
    }

    private Post CreatePost(ReferenceId? authorId = null, Header header = null, Body? body = null, bool @private = false)
    {
        Post post = null;

        authorId = CreateAuthor(authorId);

        header = CreateHeader(header);

        body = CreateBody(body);

        post = new Post(authorId.Value, header, body.Value);

        if (@private)
            post.MakePrivate();

        return post;
    }

    private ReferenceId CreateAuthor(ReferenceId? authorId = null) => authorId ?? new ReferenceId(Guid.NewGuid());

    private Header CreateHeader(Header header = null)
    {
        if (header is null)
        {
            string title = _faker.Music.Genre();
            string subTitle = _faker.Music.Genre();

            header = new Header(
                title.Substring(0, Math.Min(title.Length, PostConstants.MAX_TITLE_LENGTH)),
                subTitle.Substring(0, Math.Min(subTitle.Length, PostConstants.MAX_SUBTITLE_LENGTH)));
        }

        return header;
    }

    private Body CreateBody(Body? body = null)
    {
        if (body is null)
        {
            string content = _faker.Lorem.Letter(Random.Shared.Next(PostConstants.MAX_POST_BODY_LENGTH));
            body = content.Substring(0, Math.Min(content.Length, PostConstants.MAX_POST_BODY_LENGTH));
        }

        return body.Value;
    }
}