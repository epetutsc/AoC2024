using System.IO.Abstractions;

namespace _07;

public class InputReader(IFileSystem fileSystem)
{
    public async Task<IReadOnlyList<Line>> ReadFileAsync(string file)
    {
        return (await fileSystem.File.ReadAllLinesAsync(file))
            .Select(Line.Parse)
            .ToArray();
    }
}
