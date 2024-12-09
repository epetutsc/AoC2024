using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _08.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                ..........
                ...#......
                #.........
                ....a.....
                ........a.
                .....a....
                ..#.......
                ......#...
                ..........
                ..........
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var lines = await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            lines.GetLength(0).Should().Be(10);
            lines.GetLength(1).Should().Be(10);
        }
    }
}