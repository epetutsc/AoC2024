using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _07.Tests;

public class CalculatorTests
{
    [Fact]
    public async Task Simple_example()
    {
        const string input = """
            190: 10 19
            3267: 81 40 27
            83: 17 5
            156: 15 6
            7290: 6 8 6 15
            161011: 16 10 13
            192: 17 8 14
            21037: 9 7 18 13
            292: 11 6 16 20
            """;

        var fileSystem = new MockFileSystem();
        fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
        var inputReader = new InputReader(fileSystem);

        var lines = await inputReader.ReadFileAsync(@"C:\temp\input.txt");
        var calc = new Calculator(lines, OperatorProvider.OperatorsPart1);
        var sum = calc.Sum();

        sum.Should().Be(3749);
    }
}