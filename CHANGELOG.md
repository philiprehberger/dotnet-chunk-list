# Changelog

## 0.1.8 (2026-03-24)

- Add unit tests
- Add test step to CI workflow

## 0.1.7 (2026-03-22)

- Add dates to changelog entries

## 0.1.6 (2026-03-21)

- Align README and csproj descriptions

## 0.1.5 (2026-03-20)

- Expand README with custom size, extension method, and edge case examples
- Add LangVersion and TreatWarningsAsErrors to csproj

## 0.1.4 (2026-03-16)

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
