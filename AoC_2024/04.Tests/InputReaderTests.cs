using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _04.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                MMMSXXMASM
                MSAMXMSMSA
                AMXSXMAAMM
                MSAMASMSMX
                XMASAMXAMM
                XXAMMXXAMA
                SMSMSASXSS
                SAXAMASAAA
                MAMMMXMMMM
                MXMXAXMASX
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            
            inputReader.Input.Count.Should().Be(10);
            inputReader.Input[0].Length.Should().Be(10);
        }
   }
}