using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using System;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities;

public class PostFacts
{
    [Fact]
    public void Constructor_PassingValidAuthor_ShouldCreatePost()
    {
        //Arrange
        Guid authorId = Guid.NewGuid();
        Author author = new Author(authorId);

        //Act
        Post sut = CreateSUT(author: author);

        //Assert
        sut.Author.Should().NotBeNull();
        sut.Author.Id.Should().Be(authorId);
    }

    [Fact]
    public void Constructor_PassingNullAuthor_ShouldThrowDomainArgumentException()
    {
        //Arrange
        Author author = null;

        //Act
        Action sut = () => new Post(author, CreateHeader(), CreateBody());

        //Assert
        sut.Should().Throw<DomainArgumentException>();
    }

    private Post CreateSUT(Author author = null, Header header = null, Body body = null, bool excluded = false)
    {
        Post sut = null;

        author = CreateAuthor(author);

        header = CreateHeader(header);

        body = CreateBody(body);

        sut = new Post(author, header, body);

        if (excluded)
            sut.MakePrivate();

        return sut;
    }

    private static Author CreateAuthor(Author author = null) => author ?? new Author(Guid.NewGuid());

    private static Header CreateHeader(Header header = null)
    {
        if (header is null)
        {
            string title = new Faker().Music.Genre();
            string subTitle = new Faker().Music.Genre();

            header = new Header(
                title.Substring(0, Math.Min(title.Length, PostConstants.MAX_TITLE_LENGTH)),
                subTitle.Substring(0, Math.Min(subTitle.Length, PostConstants.MAX_SUBTITLE_LENGTH)));
        }

        return header;
    }

    private static Body CreateBody(Body body = null)
    {
        if (body is null)
        {
            string content = new Faker().Lorem.Paragraphs(10);
            body = content.Substring(0, Math.Min(content.Length, PostConstants.MAX_POST_BODY_LENGTH));
        }

        return body;
    }
}