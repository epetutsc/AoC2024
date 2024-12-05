using System.IO.Abstractions;

namespace _05;

public class InputReader(IFileSystem fileSystem)
{
    private readonly List<(int Left, int Right)> _rules = [];
    private readonly List<int[]> _updates = [];
    public IReadOnlyList<(int Left, int Right)> Rules => _rules;
    public IReadOnlyList<int[]> Updates => _updates;

    public async Task ReadFileAsync(string file)
    {
        var lines = await fileSystem.File.ReadAllLinesAsync(file);
        foreach (var line in lines)
        {
            if (line.Contains("|"))
            {
                var parts = line.Split("|");
                _rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }
            else if (line.Contains(","))
            {
                var parts = line.Split(",").Select(int.Parse).ToArray();
                _updates.Add(parts);
            }
        }
    }
}
