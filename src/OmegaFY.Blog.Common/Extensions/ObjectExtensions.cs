﻿namespace OmegaFY.Blog.Common.Extensions;

public static class ObjectExtensions
{
    public static bool In<T>(this T value, params T[] valuesToCompare)
    {
        if (valuesToCompare.IsEmpty()) return false;

        return valuesToCompare.Any(x => x.Equals(value));
    }

    public static string ToJson(this object value) => System.Text.Json.JsonSerializer.Serialize(value);
}