﻿using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;

public sealed record class AvaliationFromPost
{
    public Guid AvaliationId { get; set; }

    public Guid PostId { get; set; }

    public string PostTitle { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public Stars Rate { get; set; }

    public DateTime AvaliationDate { get; set; }

    public bool HasAvaliationBeenEdit { get; set; }
}