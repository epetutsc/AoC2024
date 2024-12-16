using FluentAssertions;

namespace _12.Tests;

public class RegionTests
{
    [Fact]
    public void Can_create_regions()
    {
        var input = new Plot[,]
        {
            { new("A"), new("B") },
            { new("C"), new("D") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Should().HaveCount(4);
    }

    [Fact]
    public void Can_create_regions_with_same_plants()
    {
        var input = new Plot[,]
        {
            { new("A"), new("A") },
            { new("A"), new("A") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Should().HaveCount(1);
        regions.Should().AllSatisfy(r => r.Plots.Should().HaveCount(4));
    }

    [Fact]
    public void Can_have_enclosing_region()
    {
        var input = new Plot[,]
        {
            { new("A"), new("A"), new("A") },
            { new("A"), new("B"), new("A") },
            { new("A"), new("A"), new("A") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Should().HaveCount(2);
        regions.First().Plots.Should().HaveCount(8);
        regions.Skip(1).First().Plots.Should().HaveCount(1);
    }

    [Fact]
    public void Can_have_2_regions_with_same_plants()
    {
        var input = new Plot[,]
        {
            { new("A"), new("B"), new("A") },
            { new("A"), new("B"), new("A") },
            { new("A"), new("B"), new("A") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Should().HaveCount(3);
        regions.Count(r => r.Plant == "A").Should().Be(2);
    }

    [Fact]
    public void Region_has_perimeter()
    {
        var input = new Plot[,]
        {
            { new("A"), new("B"), new("A") },
            { new("A"), new("B"), new("A") },
            { new("A"), new("B"), new("A") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions().ToArray();

        regions[0].Perimeter.Should().Be(8);
        regions[1].Perimeter.Should().Be(8);
        regions[2].Perimeter.Should().Be(8);
    }

    [Fact]
    public void Region_has_area()
    {
        var input = new Plot[,]
        {
            { new("A"), new("A") },
            { new("A"), new("A") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions().ToArray();

        regions[0].Area.Should().Be(4);
    }

    [Fact]
    public void Region_has_price()
    {
        var input = new Plot[,]
        {
            { new("A"), new("A") },
            { new("A"), new("A") },
        };

        var plots = input.ConnectPlots();
        var region = plots.CreateRegions().Single();

        region.Price.Should().Be(4 * 8);
    }

    [Fact]
    public void Region_Example1()
    {
        var input = new Plot[,]
        {
            { new("O"), new("O"), new("O"), new("O"), new("O") },
            { new("O"), new("X"), new("O"), new("X"), new("O") },
            { new("O"), new("O"), new("O"), new("O"), new("O") },
            { new("O"), new("X"), new("O"), new("X"), new("O") },
            { new("O"), new("O"), new("O"), new("O"), new("O") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions
            .Where(r => r.Plant == "X")
            .Should()
            .AllSatisfy(r => r.Area.Should().Be(1)).And
            .AllSatisfy(r => r.Perimeter.Should().Be(4));

        var o = regions.Single(r => r.Plant == "O");
        o.Area.Should().Be(21);
        o.Perimeter.Should().Be(36);
    }


    [Fact]
    public void Region_Example2()
    {
        var input = new Plot[,]
        {
            { new("A"), new("A"), new("A"), new("A") },
            { new("B"), new("B"), new("C"), new("E") },
            { new("B"), new("B"), new("C"), new("C") },
            { new("E"), new("E"), new("E"), new("C") }
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Sum(r => r.Price).Should().Be(140);
    }

    [Fact]
    public void Region_Example3()
    {
        var input = new Plot[,]
        {
            { new("R"), new("R"), new("R"), new("R"), new("I"), new("I"), new("C"), new("C"), new("F"), new("F") },
            { new("R"), new("R"), new("R"), new("R"), new("I"), new("I"), new("C"), new("C"), new("C"), new("F") },
            { new("V"), new("V"), new("R"), new("R"), new("R"), new("C"), new("C"), new("F"), new("F"), new("F") },
            { new("V"), new("V"), new("R"), new("C"), new("C"), new("C"), new("J"), new("F"), new("F"), new("F") },
            { new("V"), new("V"), new("V"), new("V"), new("C"), new("J"), new("J"), new("C"), new("F"), new("E") },
            { new("V"), new("V"), new("I"), new("V"), new("C"), new("C"), new("J"), new("J"), new("E"), new("E") },
            { new("V"), new("V"), new("I"), new("I"), new("I"), new("C"), new("J"), new("J"), new("E"), new("E") },
            { new("M"), new("I"), new("I"), new("I"), new("I"), new("I"), new("J"), new("J"), new("E"), new("E") },
            { new("M"), new("I"), new("I"), new("I"), new("S"), new("I"), new("J"), new("E"), new("E"), new("E") },
            { new("M"), new("M"), new("M"), new("I"), new("S"), new("S"), new("J"), new("E"), new("E"), new("E") },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Sum(r => r.Price).Should().Be(1930);
    }

    [Fact]
    public void Simple_Region_has_sides()
    {
        var input = new Plot[,]
        {
            { new("C", new(0, 0)), new("A", new(1, 0)) },
            { new("C", new(0, 1)), new("C", new(1, 1)) },
        };

        var plots = input.ConnectPlots();
        var region = plots.CreateRegions().First();

        region.Sides.Should().Be(6);
    }

    [Fact]
    public void Region_Example4()
    {
        var input = new Plot[,]
        {
            { new("A", new(0, 0)), new("A", new(1, 0)), new("A", new(2, 0)), new("A", new(3, 0)) },
            { new("B", new(0, 1)), new("B", new(1, 1)), new("C", new(2, 1)), new("E", new(3, 1)) },
            { new("B", new(0, 2)), new("B", new(1, 2)), new("C", new(2, 2)), new("C", new(3, 2)) },
            { new("E", new(0, 3)), new("E", new(1, 3)), new("E", new(2, 3)), new("C", new(3, 3)) }
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Sum(r => r.Price2).Should().Be(80);
    }

    [Fact]
    public void Region_Example5()
    {
        var input = new Plot[,]
        {
            { new("O", new(0, 0)), new("O", new(1, 0)), new("O", new(2, 0)), new("O", new(3, 0)), new("O", new(4, 0)) },
            { new("O", new(0, 1)), new("X", new(1, 1)), new("O", new(2, 1)), new("X", new(3, 1)), new("O", new(4, 1)) },
            { new("O", new(0, 2)), new("O", new(1, 2)), new("O", new(2, 2)), new("O", new(3, 2)), new("O", new(4, 2)) },
            { new("O", new(0, 3)), new("X", new(1, 3)), new("O", new(2, 3)), new("X", new(3, 3)), new("O", new(4, 3)) },
            { new("O", new(0, 4)), new("O", new(1, 4)), new("O", new(2, 4)), new("O", new(3, 4)), new("O", new(4, 4)) },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Sum(r => r.Price2).Should().Be(436);
    }

    [Fact]
    public void Region_Example6()
    {
        var input = new Plot[,]
        {
            { new("E", new(0, 0)), new("E", new(1, 0)), new("E", new(2, 0)), new("E", new(3, 0)), new("E", new(4, 0)) },
            { new("E", new(0, 1)), new("X", new(1, 1)), new("X", new(2, 1)), new("X", new(3, 1)), new("X", new(4, 1)) },
            { new("E", new(0, 2)), new("E", new(1, 2)), new("E", new(2, 2)), new("E", new(3, 2)), new("E", new(4, 2)) },
            { new("E", new(0, 3)), new("X", new(1, 3)), new("X", new(2, 3)), new("X", new(3, 3)), new("X", new(4, 3)) },
            { new("E", new(0, 4)), new("E", new(1, 4)), new("E", new(2, 4)), new("E", new(3, 4)), new("E", new(4, 4)) },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Sum(r => r.Price2).Should().Be(236);
    }

    [Fact]
    public void Region_Example7()
    {
        var input = new Plot[,]
        {
            { new("A", new(0, 0)), new("A", new(1, 0)), new("A", new(2, 0)), new("A", new(3, 0)), new("A", new(4, 0)), new("A", new(5, 0)) },
            { new("A", new(0, 1)), new("A", new(1, 1)), new("A", new(2, 1)), new("B", new(3, 1)), new("B", new(4, 1)), new("A", new(5, 1)) },
            { new("A", new(0, 2)), new("A", new(1, 2)), new("A", new(2, 2)), new("B", new(3, 2)), new("B", new(4, 2)), new("A", new(5, 2)) },
            { new("A", new(0, 3)), new("B", new(1, 3)), new("B", new(2, 3)), new("A", new(3, 3)), new("A", new(4, 3)), new("A", new(5, 3)) },
            { new("A", new(0, 4)), new("B", new(1, 4)), new("B", new(2, 4)), new("A", new(3, 4)), new("A", new(4, 4)), new("A", new(5, 4)) },
            { new("A", new(0, 5)), new("A", new(1, 5)), new("A", new(2, 5)), new("A", new(3, 5)), new("A", new(4, 5)), new("A", new(5, 5)) },
        };

        var plots = input.ConnectPlots();
        var regions = plots.CreateRegions();

        regions.Sum(r => r.Price2).Should().Be(368);
    }
}
