using System.Drawing;
using System.IO.Abstractions;
namespace _12;

public partial class InputReader(IFileSystem fileSystem)
{
    public async Task<Plot[,]> ReadFileAsync(string file)
    {
        var lines = await fileSystem.File.ReadAllLinesAsync(file);
        Plot[,] result = null!;
        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            result ??= new Plot[lines.Length, line.Length];

            for (var x = 0; x < line.Length; x++)
            {
                result[y, x] = new Plot($"{line[x]}", new Point(x, y));
            }
        }

        return result;
    }
}
