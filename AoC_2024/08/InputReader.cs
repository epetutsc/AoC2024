using System.IO.Abstractions;

namespace _08;

public class InputReader(IFileSystem fileSystem)
{
    public async Task<char[,]> ReadFileAsync(string file)
    {
        var content = await fileSystem.File.ReadAllTextAsync(file);
        return FromString(content);
    }

    public static char[,] FromString(string content)
    {
        char[,]? input = null;
        var lines = content.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        for (var row = 0; row < lines.Length; row++)
        {
            var columns = lines[row].ToCharArray();
            input ??= new char[lines.Length, columns.Length];
            for (var column = 0; column < columns.Length; column++)
            {
                input[column, row] = columns[column];
            }
        }

        return input ?? new char[0, 0];
    }
}
