using System.IO.Abstractions;

namespace _09;

public class InputReader(IFileSystem fileSystem)
{
    public async Task<string> ReadFileAsync(string file)
    {
        return (await fileSystem.File.ReadAllTextAsync(file)).Trim();
    }
}
