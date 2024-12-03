using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;

namespace _03.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public async Task CanEnumerableMultiplications()
        {
            const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
            var expected = new[] { (2, 4), (5, 5), (11, 8), (8, 5) };
            
            const string file = @"C:\temp\input.txt";
            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(file, new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var multiplications = await inputReader.GetMultiplicationsAsync(file);

            multiplications.Count.Should().Be(4);
            multiplications.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public async Task CanHandleDosAndDonts()
        {
            const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            var expected = new[] { (2, 4), (8, 5) };
            
            const string file = @"C:\temp\input.txt";
            var fileSystem = new MockFileSystem();
            fileSystem.AddFile(file, new MockFileData(input));
            var inputReader = new InputReader(fileSystem);

            var multiplications = await inputReader.GetMultiplicationsAsync(file);

            multiplications.Count.Should().Be(2);
            multiplications.Should().BeEquivalentTo(expected);
        }
    }
}