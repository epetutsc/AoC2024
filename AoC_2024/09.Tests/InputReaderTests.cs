using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _09.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            const string input = "2333133121414131402";

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var content = await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            content.Should().Be(input);
        }
    }
}