using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _10.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                8901012
                7812187
                8743096
                9654987
                4567890
                3201901
                0132980
                1045673
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            byte[,] map = await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            map.GetLength(0).Should().Be(8);
            map.GetLength(1).Should().Be(7);
        }
    }
}