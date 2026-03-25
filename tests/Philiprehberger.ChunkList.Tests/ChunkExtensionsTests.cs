using Xunit;
namespace Philiprehberger.ChunkList.Tests;

public class ChunkExtensionsTests
{
    [Fact]
    public void ChunkBy_EvenSplit_ReturnsEqualChunks()
    {
        var result = new[] { 1, 2, 3, 4 }.ChunkBy(2).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1, 2 }, result[0]);
    }

    [Fact]
    public void ChunkBy_DelegatesToEnumerableChunker()
    {
        var source = new[] { "a", "b", "c" };
        var result = source.ChunkBy(2).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { "a", "b" }, result[0]);
        Assert.Equal(new[] { "c" }, result[1]);
    }

    [Fact]
    public void ChunkBy_InvalidSize_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new[] { 1 }.ChunkBy(0).ToList());
    }
}
