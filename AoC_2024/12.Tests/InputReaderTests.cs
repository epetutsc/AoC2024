using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _12.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                AAAA
                BBCD
                BBCC
                EEEC
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var matrix = await inputReader.ReadFileAsync(@"C:\temp\input.txt");

            matrix.GetLength(0).Should().Be(4);
            matrix.GetLength(1).Should().Be(4);

            matrix[0, 0].Plant.Should().Be("A");
            matrix[3, 0].Plant.Should().Be("E");
            matrix[0, 3].Plant.Should().Be("A");
            matrix[3, 3].Plant.Should().Be("C");
        }
    }
}
