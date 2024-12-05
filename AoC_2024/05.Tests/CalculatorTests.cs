using FluentAssertions;

namespace _05.Tests;

public class CalculatorTests
{
    [Fact]
    public void CanCalculateResult()
    {
        var updates = new List<int[]>
        {
            new[] { 75, 47, 61, 53, 29 },
            new[] { 97, 61, 53, 29, 13 },
            new[] { 75, 29, 13 },
        };
        var calculator = new Calculator(updates);
        calculator.Sum.Should().Be(61 + 53 + 29);
    }
}
