namespace Philiprehberger.ChunkList;

public static class EnumerableChunker
{
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

public static class ChunkExtensions
{
    public static IEnumerable<IReadOnlyList<T>> ChunkBy<T>(this IEnumerable<T> source, int size)
        => EnumerableChunker.Chunk(source, size);
}
