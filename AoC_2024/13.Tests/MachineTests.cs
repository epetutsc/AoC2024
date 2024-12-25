using FluentAssertions;
using System.Drawing;

namespace _13.Tests;

public class MachineTests
{
    [Fact]
    public void MoveToPrize_sample1()
    {
        var machine = new Machine
        {
            A = new Point(94, 34),
            B = new Point(22, 67),
            Prize = new Point(8400, 5400)
        };

        var result = machine.MoveToPrize();
        result.Should().NotBeNull();
        result!.CountA.Should().Be(80);
        result.CountB.Should().Be(40);
        result.TotalTokens.Should().Be(280);
    }

    [Fact]
    public void MoveToPrize_sample2_no_result()
    {
        var machine = new Machine
        {
            A = new Point(26, 66),
            B = new Point(67, 21),
            Prize = new Point(12748, 12176)
        };

        var result = machine.MoveToPrize();
        result.Should().BeNull();
    }

    [Fact]
    public void MoveToPrize_sample3()
    {
        var machine = new Machine
        {
            A = new Point(17, 86),
            B = new Point(84, 37),
            Prize = new Point(7870, 6450)
        };

        var result = machine.MoveToPrize();
        result.Should().NotBeNull();
        result!.CountA.Should().Be(38);
        result.CountB.Should().Be(86);
        result.TotalTokens.Should().Be(200);
    }

    [Fact]
    public void MoveToPrize_sample4_no_result()
    {
        var machine = new Machine
        {
            A = new Point(69, 23),
            B = new Point(27, 71),
            Prize = new Point(18641, 10279)
        };

        var result = machine.MoveToPrize();
        result.Should().BeNull();
    }
}
