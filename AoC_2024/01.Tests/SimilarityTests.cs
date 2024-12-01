using FluentAssertions;

namespace _01;

public class SimilarityTests
{
    [Theory]
    [InlineData(3, 9)]
    [InlineData(4, 4)]
    [InlineData(2, 0)]
    [InlineData(1, 0)]
    public void CanCalculateSimilarity(int value, int expected)
    {
        int[] values = [4, 3, 5, 3, 9, 3];
        var similarity = new Similarity(values);
        var total = similarity.Calculate(value);
        total.Should().Be(expected);
    }

    [Fact]
    public void CanCalculateTotalSimilarity()
    {
        int[] column1 = [3, 4, 2, 1, 3, 3];
        int[] column2 = [4, 3, 5, 3, 9, 3];
        var similarity = new Similarity(column2);
        var total = similarity.CalculateTotal(column1);
        total.Should().Be(31);
    }
}
