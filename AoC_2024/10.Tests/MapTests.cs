using FluentAssertions;
using System.Drawing;

namespace _10.Tests;

public class MapTests
{
    [Fact]
    public void Finds_all_trailheads()
    {
        byte[,] input = new byte[,]
        {
            { 0, 1, 2, 3 },
            { 1, 2, 3, 4 },
            { 8, 7, 6, 5 },
            { 9, 8, 0, 6 }
        };

        var map = new Map(input);
        var trailheads = map.FindTrailheads();

        trailheads.Should().BeEquivalentTo([ new Point(0, 0), new Point(2, 3) ]);
    }

    [Fact]
    public void Can_get_score_1()
    {
        byte[,] input = new byte[,]
        {
            { 1, 1, 1, 0, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 2, 1, 1, 1 },
            { 6, 5, 4, 3, 4, 5, 6 },
            { 7, 1, 1, 1, 1, 1, 7 },
            { 8, 1, 1, 1, 1, 1, 8 },
            { 9, 1, 1, 1, 1, 1, 9 }
        };

        var map = new Map(input);
        var score = map.GetScore(new Point(3, 0));

        score.Should().Be(2);
    }

    [Fact]
    public void Can_get_score_2()
    {
        byte[,] input = new byte[,]
        {
            { 1, 1, 9, 0, 1, 1, 9 },
            { 1, 1, 1, 1, 1, 9, 8 },
            { 1, 1, 1, 2, 1, 1, 7 },
            { 6, 5, 4, 3, 4, 5, 6 },
            { 7, 6, 5, 1, 9, 8, 7 },
            { 8, 7, 6, 1, 1, 1, 1 },
            { 9, 8, 7, 1, 1, 1, 1 }
        };

        var map = new Map(input);
        var score = map.GetScore(new Point(3, 0));

        score.Should().Be(4);
    }

    [Fact]
    public void Can_get_score_3()
    {
        byte[,] input = new byte[,]
        {
            { 1, 0, 1, 1, 9, 1, 1 },
            { 2, 1, 1, 1, 8, 1, 1 },
            { 3, 1, 1, 1, 7, 1, 1 },
            { 4, 5, 6, 7, 6, 5, 4 },
            { 1, 1, 1, 8, 1, 1, 3 },
            { 1, 1, 1, 9, 1, 1, 2 },
            { 1, 1, 1, 1, 1, 0, 1 }
        };

        var map = new Map(input);
        var score = map.GetScore(new Point(1, 0), new Point(5, 6));

        score.Should().Be(3);
    }

    [Fact]
    public void Can_get_score_4()
    {
        byte[,] input = new byte[,]
        {
            { 8, 9, 0, 1, 0, 1, 2, 3 },
            { 7, 8, 1, 2, 1, 8, 7, 4 },
            { 8, 7, 4, 3, 0, 9, 6, 5 },
            { 9, 6, 5, 4, 9, 8, 7, 4 },
            { 4, 5, 6, 7, 8, 9, 0, 3 },
            { 3, 2, 0, 1, 9, 0, 1, 2 },
            { 0, 1, 3, 2, 9, 8, 0, 1 },
            { 1, 0, 4, 5, 6, 7, 3, 2 }
        };

        var map = new Map(input);
        IEnumerable<Point> trailheads = map.FindTrailheads().ToList();
        var score = map.GetScore(trailheads);

        score.Should().Be(36);
    }

    [Fact]
    public void Can_get_rating_1()
    {
        byte[,] input = new byte[,]
        {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 4, 3, 2, 1, 0 },
            { 0, 0, 5, 0, 0, 2, 0 },
            { 0, 0, 6, 5, 4, 3, 0 },
            { 0, 0, 7, 0, 0, 4, 0 },
            { 0, 0, 8, 7, 6, 5, 0 },
            { 0, 0, 9, 0, 0, 0, 0 },
        };

        var map = new Map(input);
        var score = map.GetRating(new Point(5, 0));

        score.Should().Be(3);
    }

    [Fact]
    public void Can_get_rating_2()
    {
        byte[,] input = new byte[,]
        {
            { 0, 0, 9, 0, 0, 0, 9 },
            { 0, 0, 0, 1, 0, 9, 8 },
            { 0, 0, 0, 2, 0, 0, 7 },
            { 6, 5, 4, 3, 4, 5, 6 },
            { 7, 6, 5, 0, 9, 8, 7 },
            { 8, 7, 6, 0, 0, 0, 0 },
            { 9, 8, 7, 0, 0, 0, 0 },
        };

        var map = new Map(input);
        var score = map.GetRating(new Point(3, 0));

        score.Should().Be(13);
    }

    [Fact]
    public void Can_get_rating_3()
    {
        byte[,] input = new byte[,]
        {
            { 0, 1, 2, 3, 4, 5 },
            { 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7 },
            { 3, 4, 5, 6, 7, 8 },
            { 4, 0, 6, 7, 8, 9 },
            { 5, 6, 7, 8, 9, 0 },
        };

        var map = new Map(input);
        var score = map.GetRating(new Point(0, 0));

        score.Should().Be(227);
    }

    [Fact]
    public void Can_get_rating_4()
    {
        byte[,] input = new byte[,]
        {
            { 8, 9, 0, 1, 0, 1, 2, 3 },
            { 7, 8, 1, 2, 1, 8, 7, 4 },
            { 8, 7, 4, 3, 0, 9, 6, 5 },
            { 9, 6, 5, 4, 9, 8, 7, 4 },
            { 4, 5, 6, 7, 8, 9, 0, 3 },
            { 3, 2, 0, 1, 9, 0, 1, 2 },
            { 0, 1, 3, 2, 9, 8, 0, 1 },
            { 1, 0, 4, 5, 6, 7, 3, 2 },
        };

        var map = new Map(input);
        var trailHeads = map.FindTrailheads();
        var score = map.GetRating(trailHeads);

        score.Should().Be(81);
    }
}
