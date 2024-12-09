using FluentAssertions;

namespace _07.Tests;

public class LineTests
{
    [Fact]
    public void Line_can_be_parsed()
    {
        var l = Line.Parse("190: 10 19");
        l.Result.Should().Be(190);
        l.Numbers.Should().Contain([10, 19]);
    }
}