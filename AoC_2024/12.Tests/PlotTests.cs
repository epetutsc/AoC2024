using FluentAssertions;

namespace _12.Tests;

public class PlotTests
{
    [Fact]
    public void Plots_are_conntected()
    {
        var plots = new[,]
        {
            { new Plot("A"), new Plot("B") },
            { new Plot("C"), new Plot("D") },
        };

        var allPlots = plots.ConnectPlots();

        plots[0, 0].Left.Should().BeNull();
        plots[0, 0].Top.Should().BeNull();
        plots[0, 0].Right.Should().Be(plots[0, 1]);
        plots[0, 0].Bottom.Should().Be(plots[1, 0]);

        plots[0, 1].Left.Should().Be(plots[0, 0]);
        plots[0, 1].Top.Should().BeNull();
        plots[0, 1].Right.Should().BeNull();
        plots[0, 1].Bottom.Should().Be(plots[1, 1]);

        plots[1, 0].Left.Should().BeNull();
        plots[1, 0].Top.Should().Be(plots[0, 0]);
        plots[1, 0].Right.Should().Be(plots[1, 1]);
        plots[1, 0].Bottom.Should().BeNull();

        plots[1, 1].Left.Should().Be(plots[1, 0]);
        plots[1, 1].Top.Should().Be(plots[0, 1]);
        plots[1, 1].Right.Should().BeNull();
        plots[1, 1].Bottom.Should().BeNull();

        allPlots.Should().HaveCount(4);
    }

    [Fact]
    public void Plot_has_perimeter()
    {
        new Plot("A").Perimeter.Should().Be(4);

        new Plot("A") { Left = new Plot("A") }.Perimeter.Should().Be(3);
        new Plot("A") { Top = new Plot("A") }.Perimeter.Should().Be(3);
        new Plot("A") { Right = new Plot("A") }.Perimeter.Should().Be(3);
        new Plot("A") { Bottom = new Plot("A") }.Perimeter.Should().Be(3);

        new Plot("A")
        {
            Left = new Plot("A"),
            Top = new Plot("A"),
            Right = new Plot("A"),
            Bottom = new Plot("A"),
        }.Perimeter.Should().Be(0);

        new Plot("A")
        {
            Left = new Plot("B"),
            Top = new Plot("B"),
            Right = new Plot("B"),
            Bottom = new Plot("B"),
        }.Perimeter.Should().Be(4);

        new Plot("A")
        {
            Left = new Plot("A"),
            Top = new Plot("B"),
            Right = new Plot("B"),
            Bottom = new Plot("B"),
        }.Perimeter.Should().Be(3);
    }


    [Fact]
    public void Plot_has_sides()
    {
        new Plot("A", new(1, 2)).SideX.Should().Equal(["XT_2_1-XT_2_1", "XB_2_1-XB_2_1"]);
        new Plot("A", new(1, 2)).SideY.Should().Equal(["YL_2_1-YL_2_1", "YR_2_1-YR_2_1"]);

        new Plot("A", new(1, 2)) { Left = new Plot("A", new(0, 2)) }.SideX.Should().Equal(["XT_2_0-XT_2_1", "XB_2_0-XB_2_1"]);
        new Plot("A", new(1, 2)) { Top = new Plot("A", new(1, 1)) }.SideY.Should().Equal(["YL_1_1-YL_2_1", "YR_1_1-YR_2_1"]);
        new Plot("A", new(1, 2)) { Right = new Plot("A", new(2, 2)) }.SideX.Should().Equal(["XT_2_1-XT_2_2", "XB_2_1-XB_2_2"]);
        new Plot("A", new(1, 2)) { Bottom = new Plot("A", new(1, 3)) }.SideY.Should().Equal(["YL_2_1-YL_3_1", "YR_2_1-YR_3_1"]);
    }
}
