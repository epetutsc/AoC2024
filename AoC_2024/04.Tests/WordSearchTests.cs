using FluentAssertions;

namespace _04.Tests
{
    public class WordSearchTests
    {
        [Fact]
        public void FindXmas()
        {
            List<string> input =
            [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            ];

            var search = new WordSearch(input);
            var count = search.CountWord("XMAS");
            count.Should().Be(18);
        }
        
        [Fact]
        public void FindX_MAS()
        {
            List<string> input =
            [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            ];

            var search = new WordSearch(input);
            var count = search.CountX("MAS");
            count.Should().Be(9);
        }

    }
}