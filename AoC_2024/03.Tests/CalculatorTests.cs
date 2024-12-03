using FluentAssertions;

namespace _03.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public async Task CanSumMultiplications()
        {
            var input = new[] { (2, 4), (5, 5), (11, 8), (8, 5) };
            var calc = new Calculator(input);

            var sum = calc.AddMultiplications();
            
            sum.Should().Be(161);
        }
    }
}