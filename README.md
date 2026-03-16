# Philiprehberger.ChunkList

[![CI](https://github.com/philiprehberger/dotnet-chunk-list/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-chunk-list/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.ChunkList.svg)](https://www.nuget.org/packages/Philiprehberger.ChunkList)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-chunk-list)](LICENSE)

Split any `IEnumerable<T>` into fixed-size chunks with a simple static method or LINQ-style extension.

## Install

```bash
dotnet add package Philiprehberger.ChunkList
```

## Usage

```csharp
using Philiprehberger.ChunkList;

var numbers = Enumerable.Range(1, 10);

// Static method
foreach (var chunk in EnumerableChunker.Chunk(numbers, 3))
{
    Console.WriteLine(string.Join(", ", chunk));
}
// 1, 2, 3
// 4, 5, 6
// 7, 8, 9
// 10

// Extension method
var chunks = numbers.ChunkBy(4).ToList();
// chunks[0] == [1, 2, 3, 4]
// chunks[1] == [5, 6, 7, 8]
// chunks[2] == [9, 10]

// Works with any sequence
var words = new[] { "a", "b", "c", "d", "e" };
var pairs = words.ChunkBy(2);
// ["a","b"], ["c","d"], ["e"]
```

## API

### `EnumerableChunker`

| Method | Description |
|--------|-------------|
| `Chunk<T>(IEnumerable<T> source, int size)` | Yield `IReadOnlyList<T>` chunks of at most `size` elements |

### `ChunkExtensions`

| Method | Description |
|--------|-------------|
| `ChunkBy<T>(this IEnumerable<T> source, int size)` | Extension method — same as `EnumerableChunker.Chunk` |

**Notes:**
- The last chunk may contain fewer than `size` elements.
- Throws `ArgumentOutOfRangeException` if `size` is zero or negative.
- Enumeration is lazy — chunks are produced on demand.

## License

MIT
