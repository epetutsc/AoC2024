using System.IO.Abstractions;
namespace _11;

public partial class InputReader(IFileSystem fileSystem)
{
    public async Task<IReadOnlyList<long>> ReadFileAsync(string file)
    {
        var content = await fileSystem.File.ReadAllTextAsync(file);
        return content
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();
    }
}
