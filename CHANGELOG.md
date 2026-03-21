# Changelog

## 0.1.6 (2026-03-21)

- Align README and csproj descriptions

## 0.1.5

- Expand README with custom size, extension method, and edge case examples
- Add LangVersion and TreatWarningsAsErrors to csproj

## 0.1.4

- Add Development section to README
- Add GenerateDocumentationFile and RepositoryType to .csproj

## 0.1.1 (2026-03-10)

- Fix README path in csproj so README displays on nuget.org

## 0.1.0 (2026-03-10)

- Initial release
- `EnumerableChunker.Chunk<T>` — split any `IEnumerable<T>` into fixed-size chunks
- `ChunkExtensions.ChunkBy<T>` — extension method on `IEnumerable<T>`
- Last chunk may be smaller than the requested size
- Throws `ArgumentOutOfRangeException` when size is zero or negative
