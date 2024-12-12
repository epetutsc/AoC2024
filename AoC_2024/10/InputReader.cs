using System.IO.Abstractions;
namespace _10;

public partial class InputReader(IFileSystem fileSystem)
{
    public async Task<byte[,]> ReadFileAsync(string file)
    {
        var lines = await fileSystem.File.ReadAllLinesAsync(file);
        var result = new byte[lines.Length, lines[0].Length];
        for (var i = 0; i < result.GetLength(0); i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                result[i, j] = byte.Parse(lines[i][j].ToString());
            }
        }

        return result;
    }
}
