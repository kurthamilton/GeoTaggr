using System.Diagnostics.CodeAnalysis;

namespace GeoTaggr.Core;

public static class Any
{
    // Public methods should expose an exact number of parameters to take advantage
    // of the NotNullWhen attribute. This allows the compiler on the calling end to 
    // safely determine whether or not an argument will be null as a result of these
    // checks.

    public static bool IsNull(
        [NotNullWhen(false)] object? a)
    {
        return a == null;
    }

    public static bool IsNull(
        [NotNullWhen(false)] object? a,
        [NotNullWhen(false)] object? b)
    {
        return AnyIsNull(a, b);
    }

    public static bool IsNull(
        [NotNullWhen(false)] object? a,
        [NotNullWhen(false)] object? b,
        [NotNullWhen(false)] object? c)
    {
        return AnyIsNull(a, b, c);
    }

    public static bool IsNull(
        [NotNullWhen(false)] object? a,
        [NotNullWhen(false)] object? b,
        [NotNullWhen(false)] object? c,
        [NotNullWhen(false)] object? d)
    {
        return AnyIsNull(a, b, c, d);
    }

    public static bool IsNull(
        [NotNullWhen(false)] object? a,
        [NotNullWhen(false)] object? b,
        [NotNullWhen(false)] object? c,
        [NotNullWhen(false)] object? d,
        [NotNullWhen(false)] object? e)
    {
        return AnyIsNull(a, b, c, d, e);
    }

    public static bool IsNull(
        [NotNullWhen(false)] object? a,
        [NotNullWhen(false)] object? b,
        [NotNullWhen(false)] object? c,
        [NotNullWhen(false)] object? d,
        [NotNullWhen(false)] object? e,
        [NotNullWhen(false)] object? f)
    {
        return AnyIsNull(a, b, c, d, e, f);
    }

    public static bool IsNullOrEmpty(
        [NotNullWhen(false)] string? a,
        [NotNullWhen(false)] string? b)
    {
        return AnyIsNullOrEmpty(a, b);
    }

    private static bool AnyIsNull(params object?[] array)
    {
        return array.Any(x => x == null);
    }

    private static bool AnyIsNullOrEmpty(params string?[] array)
    {
        return array.Any(string.IsNullOrEmpty);
    }
}