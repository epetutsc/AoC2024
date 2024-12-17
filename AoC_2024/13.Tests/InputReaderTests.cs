using System.Drawing;
using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _13.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                Button A: X+19, Y+50
                Button B: X+58, Y+35
                Prize: X=13287, Y=9100
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var machines = await inputReader.ReadFileAsync(@"C:\temp\input.txt");

            machines.Should().HaveCount(1);
            machines.First().A.Should().Be(new Point(19, 50));
            machines.First().B.Should().Be(new Point(58, 35));
            machines.First().Prize.Should().Be(new Point(13287, 9100));
        }
    }
}
