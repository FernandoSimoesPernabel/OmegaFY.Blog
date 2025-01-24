﻿using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostCollectionModel
{
    public ReferenceId Id { get; set; }

    public ReferenceId AuthorId { get; set; }

    public Header Header { get; set; }

    public Body Body { get; set; }

    public ModificationDetails ModificationDetails { get; set; }

    public bool Private { get; set; }

    public double AverageRate { get; set; }

    public AvaliationCollectionModel[] Avaliations { get; set; } = [];

    public CommentCollectionModel[] Comments { get; set; } = [];

    public SharedCollectionModel[] Shareds { get; set; } = [];
}