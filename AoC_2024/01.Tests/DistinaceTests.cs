using FluentAssertions;

namespace _01.Tests;

public class DistinaceTests
{
    [Theory]
    [InlineData(1, 3, 2)]
    [InlineData(2, 3, 1)]
    [InlineData(3, 3, 0)]
    [InlineData(4, 3, 1)]
    [InlineData(3, 5, 2)]
    [InlineData(4, 9, 5)]
    public void CanCalculateDistance(int first, int second, int expected)
    {
        // Arrange
        var distance = new Distance();

        // Act
        var actual = distance.Calculate(first, second);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void CanCalculateTotalDistance()
    {
        int[] column1 = [3, 4, 2, 1, 3, 3];
        int[] column2 = [4, 3, 5, 3, 9, 3];

        var distance = new Distance();
        var total = distance.CalculateTotal(column1, column2);

        total.Should().Be(11);
    }
}
