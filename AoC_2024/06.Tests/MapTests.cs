using FluentAssertions;

namespace _06.Tests;

public class MapTests
{
    [Theory]
    [InlineData('^')]
    [InlineData('>')]
    [InlineData('v')]
    [InlineData('<')]
    public void Map_can_find_guard(char direction)
    {
        var input = $"""
            .     .     .
            .{direction}.
            .     .     .
            """;

        var map = Map.FromString(input);
        map.Find(direction).Should().Be(new Position(1, 1));
    }

    [Theory]
    [InlineData('^', '>')]
    [InlineData('>', 'v')]
    [InlineData('v', '<')]
    [InlineData('<', '^')]
    public void Map_can_set_guard_direction(char initialDirection, char finalDirection)
    {
        var input = $"""
        .        .         .
        .{initialDirection}.
        .        .         .
        """;

        var map = Map.FromString(input);
        map.Set(new Position(1, 1), finalDirection);
        
        map.Get(new Position(1, 1)).Should().Be(finalDirection);
    }
    
    [Theory]
    [InlineData('.')]
    [InlineData('#')]
    public void Map_can_get_position(char obstacle)
    {
        var input = $"""
                     .    .     .  
                     .{obstacle}.
                     .    .     .
                     """;

        var map = Map.FromString(input);
        map.Get(new Position(1, 1)).Should().Be(obstacle);
    }
}
