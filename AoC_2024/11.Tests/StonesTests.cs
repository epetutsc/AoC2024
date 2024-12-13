using FluentAssertions;

namespace _11.Tests;

public class StonesTests
{
    [Fact]
    public void Stone_0_changes_to_1()
    {
        IEnumerable<long> initial = [0];
        var list = initial.Blink();
        list.Should().HaveCount(1);
        list.First().Should().Be(1);
    }

    [Fact]
    public void Stone_with_even_numbers_splits_into_two()
    {
        IEnumerable<long> initial = [1001];
        var list = initial.Blink();
        list.Should().HaveCount(2);
        list.First().Should().Be(10);
        list.Skip(1).First().Should().Be(1);
    }

    [Fact]
    public void Stone_is_replaced_and_multiplied()
    {
        IEnumerable<long> initial = [111];
        var list = initial.Blink();
        list.Should().ContainSingle();
        list.First().Should().Be(111 * 2024);
    }

    [Fact]
    public void Stones_example1()
    {
        IEnumerable<long> initial =
        [
            0,
            1,
            10,
            99,
            999
        ];

        var list = initial.Blink();
        list.Should().Equal(
        [
            1,
            2024,
            1,
            0,
            9,
            9,
            2021976
        ]);
    }

    [Fact]
    public void Stones_example2()
    {
        IEnumerable<long> initial = [ 125, 17 ];

        var list = initial.Blink(6);
        list.Should().Equal(
        [
            2097446912,
            14168,
            4048,
            2,
            0,
            2,
            4,
            40,
            48,
            2024,
            40,
            48,
            80,
            96,
            2,
            8,
            6,
            7,
            6,
            0,
            3,
            2
        ]);

        initial.Count(6).Should().Be(22);
        initial.Count(25).Should().Be(55312);
    }

    [Fact]
    public void Stones_performance()
    {
        IEnumerable<long> initial = [0];

        var result = initial.Count(75);
        result.Should().BePositive();
    }
}
