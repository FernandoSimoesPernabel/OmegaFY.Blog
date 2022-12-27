﻿using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Posts.PublishPost;

public class PublishPostCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public DateTime DateOfCreation { get; set; }

    public PublishPostCommandResult() { }

    public PublishPostCommandResult(Guid id, Guid authorId, string title, string subTitle, string body, DateTime dateOfCreation)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        SubTitle = subTitle;
        Body = body;
        DateOfCreation = dateOfCreation;
    }
}