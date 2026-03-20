namespace Philiprehberger.ChunkList;

/// <summary>Splits sequences into fixed-size chunks.</summary>
public static class EnumerableChunker
{
    /// <summary>Splits <paramref name="source"/> into chunks of at most <paramref name="size"/> elements.</summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The sequence to partition.</param>
    /// <param name="size">Maximum number of elements per chunk.</param>
    /// <returns>An enumerable of read-only lists, each containing up to <paramref name="size"/> elements.</returns>
    public static IEnumerable<IReadOnlyList<T>> Chunk<T>(IEnumerable<T> source, int size)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Chunk size must be greater than zero.");

        return ChunkIterator(source, size);
    }

    private static IEnumerable<IReadOnlyList<T>> ChunkIterator<T>(IEnumerable<T> source, int size)
    {
        var chunk = new List<T>(size);

        foreach (var item in source)
        {
            chunk.Add(item);
            if (chunk.Count == size)
            {
                yield return chunk.AsReadOnly();
                chunk = new List<T>(size);
            }
        }

        if (chunk.Count > 0)
            yield return chunk.AsReadOnly();
    }
}

/// <summary>Extension methods for chunking enumerables.</summary>
public static class ChunkExtensions
{
    /// <summary>Splits the sequence into chunks of at most <paramref name="size"/> elements.</summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The sequence to partition.</param>
    /// <param name="size">Maximum number of elements per chunk.</param>
    /// <returns>An enumerable of read-only lists, each containing up to <paramref name="size"/> elements.</returns>
    public static IEnumerable<IReadOnlyList<T>> ChunkBy<T>(this IEnumerable<T> source, int size)
        => EnumerableChunker.Chunk(source, size);
}
