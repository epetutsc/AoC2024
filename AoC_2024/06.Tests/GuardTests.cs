using FluentAssertions;

namespace _06.Tests;

public class GuardTests
{
    [Theory]
    [InlineData('^', '.', 0, 1)]
    [InlineData('>', '.', 1, 2)]
    [InlineData('v', '.', 2, 1)]
    [InlineData('<', '.', 1, 0)]
    [InlineData('^', '#', 0, 1)]
    [InlineData('>', '#', 1, 2)]
    [InlineData('v', '#', 2, 1)]
    [InlineData('<', '#', 1, 0)]
    public void Guard_can_peek_move(char direction, char obstacle, int row, int column)
    {
        var input = $"""
                     .         {obstacle}          .
                     {obstacle}{direction}{obstacle}
                     .         {obstacle}          .
                     """;

        var map = Map.FromString(input);
        var guard = new Guard(map);
        guard.PeekMove().Should().Be(new Position(row, column));
    }
    
    [Theory]
    [InlineData('^', '.', 0, 1)]
    [InlineData('>', '.', 1, 2)]
    [InlineData('v', '.', 2, 1)]
    [InlineData('<', '.', 1, 0)]
    [InlineData('^', '#', 0, 1)]
    [InlineData('>', '#', 1, 2)]
    [InlineData('v', '#', 2, 1)]
    [InlineData('<', '#', 1, 0)]
    public void Guard_can_move(char direction, char obstacle, int row, int column)
    {
        var input = $"""
                     .         {obstacle}          .
                     {obstacle}{direction}{obstacle}
                     .         {obstacle}          .
                     """;

        var map = Map.FromString(input);
        var guard = new Guard(map);
        guard.Move();
        guard.Position.Should().Be(new Position(row, column));
    }

    [Theory]
    [InlineData('^', '>')]
    [InlineData('>', 'v')]
    [InlineData('v', '<')]
    [InlineData('<', '^')]
    public void Guard_can_turn(char initialDirection, char finalDirection)
    {
        var input = $"""
                     .        #         .
                     #{initialDirection}#
                     .        #         .
                     """;

        var map = Map.FromString(input);
        var guard = new Guard(map);
        guard.Turn();
        
        guard.Direction.Should().Be(finalDirection);
    }
}
