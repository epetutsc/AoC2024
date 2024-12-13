using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _11.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = """
                125 17
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var numbers = await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            numbers.Should().Equal([125, 17]);
        }
    }
}
