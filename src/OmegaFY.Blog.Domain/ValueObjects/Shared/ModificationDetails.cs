﻿namespace OmegaFY.Blog.Domain.ValueObjects.Shared;

public readonly record struct ModificationDetails
{
    public DateTime DateOfCreation { get; }

    public DateTime? DateOfModification { get; }

    public ModificationDetails()
    {
        DateOfCreation = DateTime.UtcNow;
        DateOfModification = null;
    }

    public ModificationDetails(DateTime dateOfCreation)
    {
        DateOfCreation = dateOfCreation;
        DateOfModification = DateTime.UtcNow;
    }

    public ModificationDetails(DateTime dateOfCreation, DateTime? dateOfModification)
    {
        DateOfCreation = dateOfCreation;
        DateOfModification = dateOfModification;
    }
}