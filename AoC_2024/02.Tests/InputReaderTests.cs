using FluentAssertions;
using System.IO.Abstractions.TestingHelpers;

namespace _02.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            var input = """
                7 6 4 2 1
                1 2 7 8 9
                9 7 6 2 1
                1 3 2 4 5
                8 6 4 4 1
                1 3 6 7 9
                """;

            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            var reports = inputReader.Reports;

            reports.Count.Should().Be(6);
            reports[0].Count.Should().Be(5);
        }
    }
}