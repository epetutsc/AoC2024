using System.Drawing;
using System.IO.Abstractions;
using System.Text.RegularExpressions;

namespace _13;

public partial class InputReader(IFileSystem fileSystem)
{
    [GeneratedRegex(@"Button [AB]: X\+(\d+), Y\+(\d+)")]
    private static partial Regex ButtonPattern();

    [GeneratedRegex(@"Prize: X=(\d+), Y=(\d+)")]
    private static partial Regex PrizePattern();

    public async Task<IEnumerable<Machine>> ReadFileAsync(string file)
    {
        var lines = await fileSystem.File.ReadAllLinesAsync(file);

        var result = new List<Machine>();
        for (var i = 0; i < lines.Length; i += 4)
        {
            var buttonA = ButtonPattern().Match(lines[i]);
            var x1 = int.Parse(buttonA.Groups[1].Value);
            var y1 = int.Parse(buttonA.Groups[2].Value);

            var buttonB = ButtonPattern().Match(lines[i + 1]);
            var x2 = int.Parse(buttonB.Groups[1].Value);
            var y2 = int.Parse(buttonB.Groups[2].Value);

            var prize = PrizePattern().Match(lines[i + 2]);
            var x3 = int.Parse(prize.Groups[1].Value);
            var y3 = int.Parse(prize.Groups[2].Value);

            var machine = new Machine
            {
                A = new Point(x1, y1),
                B = new Point(x2, y2),
                Prize = new Point(x3, y3)
            };

            result.Add(machine);
        }

        return result;
    }
}
