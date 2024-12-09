using System.Drawing;
using FluentAssertions;

namespace _08.Tests;

public class AntinodesTests
{
    [Fact]
    public void Antinodes_simple_test()
    {
        const string input = """
            ..........
            ...#......
            ..........
            ....a.....
            ..........
            .....a....
            ..........
            ......#...
            ..........
            ..........
            """;

        var matrix = InputReader.FromString(input);
        var antinodes = new Antinodes(matrix);
        var result = antinodes.Find().ToList();
        result.Should().Contain(new Point(3, 1));
        result.Should().Contain(new Point(6, 7));
        result.Should().HaveCount(2);
    }
    
    [Fact]
    public void Antinodes_extended_test()
    {
        const string input = """
                             ............
                             ........0...
                             .....0......
                             .......0....
                             ....0.......
                             ......A.....
                             ............
                             ............
                             ........A...
                             .........A..
                             ............
                             ............
                             """;

        var matrix = InputReader.FromString(input);
        var antinodes = new Antinodes(matrix);
        var result = antinodes.Find().ToList();
        var plot = antinodes.Plot(result);
        result.Should().HaveCount(14);
    }
}