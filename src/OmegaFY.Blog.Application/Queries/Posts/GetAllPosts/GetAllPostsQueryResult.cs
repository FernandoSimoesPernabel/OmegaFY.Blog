﻿using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

public sealed record class GetAllPostsQueryResult : GenericResult, IQueryResult
{
    public Guid PostId { get; set; }

    public string Title { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateOfCreation { get; set; }

    public bool HasPostBeenEdit { get; set; }

    public double AverageRate { get; set; }
}