using System.IO.Abstractions;

namespace _02;

public class InputReader(IFileSystem fileSystem)
{
    private readonly IFileSystem _fileSystem = fileSystem;

    private readonly List<List<int>> _reports = [];

    public IReadOnlyList<IReadOnlyList<int>> Reports => _reports;

    public async Task ReadFileAsync(string file)
    {
        var lines = await _fileSystem.File.ReadAllLinesAsync(file);
        foreach (var line in lines)
        {
            var levels = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            _reports.Add(levels);
        }
    }
}