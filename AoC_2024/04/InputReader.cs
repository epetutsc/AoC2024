using System.IO.Abstractions;

namespace _04;

public class InputReader(IFileSystem fileSystem)
{
    private readonly List<string> _input = []; 
    public IReadOnlyList<string> Input => _input;
    
    public async Task ReadFileAsync(string file)
    {
        var lines = await fileSystem.File.ReadAllLinesAsync(file);
        foreach (var line in lines)
        {
            _input.Add(line);
        }
    }
}
