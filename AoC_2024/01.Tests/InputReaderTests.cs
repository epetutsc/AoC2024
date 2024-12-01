using FluentAssertions;
using System.IO.Abstractions.TestingHelpers;

namespace _01.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanReadInputFile()
        {
            // verwende System.IO.Abstractions.IFileSystem und erstelle eine Mock-Datei,
            // die 2 Spalten mit Zahlen enthält. Die Datei soll in einem temporären Verzeichnis
            // erstellt werden
            // Arrange
            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(@"C:\temp\input.txt", new MockFileData("1 2\n3 4\n5 6\n"));
            var inputReader = new InputReader(fileSystem);

            await inputReader.ReadFileAsync(@"C:\temp\input.txt");
            IEnumerable<int> numbers1 = inputReader.Column1;
            IEnumerable<int> numbers2 = inputReader.Column2;

            numbers1.Should().BeEquivalentTo(new[] { 1, 3, 5 });
            numbers2.Should().BeEquivalentTo(new[] { 2, 4, 6 });
        }
    }
}