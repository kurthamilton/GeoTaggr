namespace GeoTaggr.Core.Extensions;

public static class EnumerableExtensions
{
    public static IReadOnlyDictionary<TKey, IReadOnlyCollection<T>> ToGroupedReadOnlyDictionary<TKey, T>(
        this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer = null) where TKey : notnull
    {
        return source
            .GroupBy(keySelector, comparer)
            .ToDictionary(x => x.Key, x => (IReadOnlyCollection<T>)x.ToArray())
            .AsReadOnly();
    }

    public static IReadOnlyDictionary<TKey, T> ToReadOnlyDictionary<TKey, T>(
        this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer = null) where TKey : notnull
    {
        return source
            .ToDictionary(keySelector, comparer)
            .AsReadOnly();
    }
}
