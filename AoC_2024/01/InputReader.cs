using System.IO.Abstractions;

namespace _01;

public class InputReader(IFileSystem fileSystem)
{
    private readonly IFileSystem _fileSystem = fileSystem;

    private readonly List<int> _column1 = [];
    private readonly List<int> _column2 = [];

    public IEnumerable<int> Column1 => _column1;
    public IEnumerable<int> Column2 => _column2;

    public async Task ReadFileAsync(string file)
    {
        var lines = await _fileSystem.File.ReadAllLinesAsync(file);
        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _column1.Add(int.Parse(parts[0]));
            _column2.Add(int.Parse(parts[1]));
        }
    }
}