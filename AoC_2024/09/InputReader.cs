using System.IO.Abstractions;
using System.Text.RegularExpressions;

namespace _09;

public partial class InputReader(IFileSystem fileSystem)
{

    [GeneratedRegex(@"\D")]
    private static partial Regex DigitsOnly();

    public async Task<string> ReadFileAsync(string file)
    {
        var content = (await fileSystem.File.ReadAllTextAsync(file));
        return DigitsOnly().Replace(content, "");
    }
}
