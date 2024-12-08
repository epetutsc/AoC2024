using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _06.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                ....#.....
                .........#
                ..........
                ..#.......
                .......#..
                ..........
                .#..^.....
                ........#.
                #.........
                ......#...
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var map = await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            map.Should().Be(input);
        }
    }
}