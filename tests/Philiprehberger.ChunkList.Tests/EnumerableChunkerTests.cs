using Xunit;
namespace Philiprehberger.ChunkList.Tests;

public class EnumerableChunkerTests
{
    [Fact]
    public void Chunk_EvenSplit_ReturnsEqualChunks()
    {
        var result = EnumerableChunker.Chunk(new[] { 1, 2, 3, 4 }, 2).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 3, 4 }, result[1]);
    }

    [Fact]
    public void Chunk_UnevenSplit_LastChunkIsSmaller()
    {
        var result = EnumerableChunker.Chunk(new[] { 1, 2, 3, 4, 5 }, 2).ToList();

        Assert.Equal(3, result.Count);
        Assert.Single(result[2]);
        Assert.Equal(5, result[2][0]);
    }

    [Fact]
    public void Chunk_SizeLargerThanSource_ReturnsSingleChunk()
    {
        var result = EnumerableChunker.Chunk(new[] { 1, 2 }, 10).ToList();

        Assert.Single(result);
        Assert.Equal(new[] { 1, 2 }, result[0]);
    }

    [Fact]
    public void Chunk_EmptySource_ReturnsNoChunks()
    {
        var result = EnumerableChunker.Chunk(Array.Empty<int>(), 3).ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void Chunk_NullSource_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            EnumerableChunker.Chunk<int>(null!, 2).ToList());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Chunk_InvalidSize_ThrowsArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            EnumerableChunker.Chunk(new[] { 1 }, size).ToList());
    }

    [Fact]
    public void Chunk_SizeOfOne_ReturnsIndividualElements()
    {
        var result = EnumerableChunker.Chunk(new[] { 10, 20, 30 }, 1).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { 10 }, result[0]);
        Assert.Equal(new[] { 20 }, result[1]);
        Assert.Equal(new[] { 30 }, result[2]);
    }
}
