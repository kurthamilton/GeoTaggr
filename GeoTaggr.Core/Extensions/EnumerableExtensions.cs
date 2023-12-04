namespace GeoTaggr.Core.Extensions;

public static class EnumerableExtensions
{
    public static int FindIndex<T>(this IReadOnlyCollection<T> collection, Predicate<T> predicate)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            T item = collection.ElementAt(i);

            if (predicate(item))
            {
                return i;
            }
        }

        return -1;
    }

    public static int IndexOf<T>(this IReadOnlyCollection<T> collection, T value)
    {
        return collection
            .FindIndex(x => x?.Equals(value) == true);
    }

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
